using ModelLibrary;
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

            var dialog = new DepositoryAccountWindow();

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
        /// <param name="depositoryAccountManager"> Менеджер депозитарных счетов </param>
        /// <param name="entityCreator"> Создатель сущностей </param>
        public DepositoryAccountDialog(DepositoryAccountManager depositoryAccountManager, 
                                       EntityCreator entityCreator)
        {
            _depositoryAccountManager = depositoryAccountManager;
            _entityCreator = entityCreator;
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
            _dialog = new AddEditBankAccountWindow();
            if (_dialog.ShowDialog() != true) return;

            var depositoryAccount = CreateAccount();
            if (depositoryAccount is null) return;

            _depositoryAccountManager.Create(depositoryAccount, _bankCustomer);
        }

        private void EditDepositoryAccount(object obj)
        {
            if (obj is IDepositoryAccount depositoryAccount)
            {
                _dialog = new AddEditBankAccountWindow();

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
