﻿using ModelLibrary;
using ServiceLibrary;
using System;

namespace DialogLibrary
{
    /// <summary>
    /// Класс диалогового окна отображения депозитарных счетов
    /// </summary>
    public class DepositoryAccountDialog
    {
        #region Закрытые поля

        private EntityCreator _entityCreator;
        private DepositoryAccountManager _depositoryAccountManager;
        private IBankCustomer _bankCustomer;
        private AddEditBankAccountWindow _dialog;
        private DialogWindowsLocator _dialogWindowsLocator;

        #endregion

        /// <summary>
        /// Открыть диалог
        /// </summary>
        /// <param name="bankCustomer"> Клиент банка </param>
        public void OpenDialog(IBankCustomer bankCustomer)
        {
            if(bankCustomer is null)
                throw new ArgumentNullException("Клиент банка не может быть null!!!");
            _bankCustomer = bankCustomer;

            var dialog = _dialogWindowsLocator.GetDepositoryAccountWindow();

            dialog.Title = "Список депозитарных счетов";
            dialog.DepositoryAccounts = _bankCustomer.DepositoryAccounts;
            dialog.DeleteDepositoryAccount += DeleteDepositoryAccount;
            dialog.CreateDepositoryAccount += CreateDepositoryAccount;
            dialog.EditDepositoryAccount += EditDepositoryAccount;

            if (dialog.ShowDialog() != true) return;
        }

        /// <summary>
        /// Конструктор
        /// </summary>        
        public DepositoryAccountDialog(DepositoryAccountManager depositoryAccountManager, 
                                       EntityCreator entityCreator,
                                       DialogWindowsLocator dialogWindowsLocator)
        {
            if (depositoryAccountManager is null)
                throw new ArgumentNullException(nameof(depositoryAccountManager), "Менеджер депозитарных счетов не может быть null!!!");
            if (entityCreator is null)
                throw new ArgumentNullException(nameof(entityCreator), "Создатель сущностей не может быть null!!!");
            if (dialogWindowsLocator is null)
                throw new ArgumentNullException(nameof(dialogWindowsLocator), "Локатор диалоговых окон не может быть null!!!");

            _depositoryAccountManager = depositoryAccountManager;
            _entityCreator = entityCreator;
            _dialogWindowsLocator = dialogWindowsLocator;
        }

        #region Закрытые методы

        private void DeleteDepositoryAccount(object obj)
        {
            if (obj is IDepositoryAccount depositoryAccount)
            {
                _depositoryAccountManager.Delete(depositoryAccount, _bankCustomer);
            }
        }

        private void CreateDepositoryAccount()
        {
            _dialog = _dialogWindowsLocator.GetAddEditBankAccountWindow();
            if (_dialog.ShowDialog() != true) return;

            var depositoryAccount = CreateAccount();
            if (depositoryAccount is null) return;

            _depositoryAccountManager.Create(depositoryAccount, _bankCustomer);
        }

        private void EditDepositoryAccount(object obj)
        {
            if (obj is IDepositoryAccount depositoryAccount)
            {
                _dialog = _dialogWindowsLocator.GetAddEditBankAccountWindow();

                _dialog.Amount = depositoryAccount.Amount;
                _dialog.InterestRate = depositoryAccount.InterestRate;
                _dialog.SelectedDepositStatus = depositoryAccount.DepositStatus;

                if (_dialog.ShowDialog() != true) return;

                var tempDepositoryAccount = CreateAccount();
                if (tempDepositoryAccount is null) return;

                tempDepositoryAccount.Id = depositoryAccount.Id;

                _depositoryAccountManager.Update(tempDepositoryAccount);
            }
        }

        /// <summary>
        /// Создать счёт
        /// </summary>        
        private IDepositoryAccount CreateAccount()
        {
            if (_dialog is null)
                throw new ArgumentNullException(nameof(_dialog));

            var amount = _dialog.Amount;
            if (amount == 0 && amount is null) return null;

            var interestRate = _dialog.InterestRate;
            if (interestRate == 0 && interestRate is null) return null;

            return _entityCreator.CreateDepositoryAccount(0,
                                                          amount,
                                                          interestRate,
                                                          _dialog.SelectedDepositStatus);
        }

        #endregion
    }
}
