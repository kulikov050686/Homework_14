using System.Collections.Generic;
using System;
using ModelLibrary;

namespace ServiceLibrary
{
    /// <summary>
    /// Менеджер депозитарного счёта
    /// </summary>
    public class DepositoryAccountManager
    {
        #region Закрытые поля

        private readonly DepositoryAccountRepository  _depositoryAccountRepository;
        private readonly BankCustomerManager _bankCustomerManager;

        #endregion

        /// <summary>
        /// Получить список всех депозитарных счетов клиентов банка
        /// </summary>
        public IList<IDepositoryAccount> DepositoryAccounts => _depositoryAccountRepository.GetAll();

        /// <summary>
        /// Обновление данных депозитарного счёта клиента банка и сохранение в репозитории
        /// </summary>
        /// <param name="depositoryAccount"> Депозитарный счёт </param>
        public void Update(IDepositoryAccount depositoryAccount)
        {
            _depositoryAccountRepository.Update(depositoryAccount);
        }

        /// <summary>
        /// Добавить новый депозотарный счёт
        /// </summary>
        /// <param name="depositoryAccount"> Депозитарный счёт </param>
        /// <param name="bankCustomer"> Клиент банка </param>
        public bool Create(IDepositoryAccount depositoryAccount,
                           IBankCustomer bankCustomer)
        {
            if (bankCustomer is null)
                throw new ArgumentNullException(nameof(bankCustomer), "Клиент банка не может быть null!!!");
            if (depositoryAccount is null)
                throw new ArgumentNullException(nameof(depositoryAccount), "Счёт не может быть null!!!");

            var selectedBankCustomer = _bankCustomerManager.Get(bankCustomer.Id);
            if (selectedBankCustomer is null) return false;

            bankCustomer.DepositoryAccounts.Add(depositoryAccount);
            _depositoryAccountRepository.Add(depositoryAccount);

            return true;
        }

        /// <summary>
        /// Удалить депозотарный счёт
        /// </summary>
        /// <param name="depositoryAccount"> Депозитарный счёт </param>
        /// <param name="bankCustomer"> Клиент банка </param>
        public bool Delete(IDepositoryAccount depositoryAccount,
                           IBankCustomer bankCustomer)
        {
            if (bankCustomer is null)
                throw new ArgumentNullException(nameof(bankCustomer), "Клиент банка не может быть null!!!");
            if (depositoryAccount is null)
                throw new ArgumentNullException(nameof(depositoryAccount), "Счёт не может быть null!!!");

            var selectedBankCustomer = _bankCustomerManager.Get(bankCustomer.Id);
            if (selectedBankCustomer is null) return false;

            if(bankCustomer.DepositoryAccounts.Remove(depositoryAccount))
            {
                _depositoryAccountRepository.Remove(depositoryAccount);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Получить депозитарный счёт по идентификатору
        /// </summary>
        /// <param name="id"> Идентификатор </param>        
        public IDepositoryAccount Get(ulong id) => _depositoryAccountRepository.Get(id);

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="depositoryAccountRepository"> Хранилище депозитарных счетов клиентов банка </param>
        /// <param name="bankCustomersManager"> Хранилище клиентов банка </param>
        public DepositoryAccountManager(DepositoryAccountRepository depositoryAccountRepository,
                                        BankCustomerManager bankCustomersManager)
        {
            if(depositoryAccountRepository is null)
                throw new ArgumentNullException(nameof(depositoryAccountRepository), "Хранилище депозитарных счетов клиентов банка не может быть null!!!");
            if(bankCustomersManager is null)
                throw new ArgumentNullException(nameof(bankCustomersManager), "Хранилище клиентов банка не может быть null!!!");

            _bankCustomerManager = bankCustomersManager;
            _depositoryAccountRepository = depositoryAccountRepository;
        }
    }
}
