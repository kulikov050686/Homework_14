using System.Collections.Generic;
using System;
using ModelLibrary;
using EnumLibrary;

namespace ServiceLibrary
{
    /// <summary>
    /// Обработчик событий менеджера
    /// </summary>
    /// <param name="sender"> Параметр события </param>
    /// <param name="args"> Действия менеджера </param>
    public delegate void ManagerEventHandler(object sender, ManagerArgs args);

    /// <summary>
    /// Менеджер Клиента банка
    /// </summary>
    public class BankCustomerManager
    {
        #region Закрытые поля

        private readonly BankCustomerRepository _bankCustomerRepository;
        private readonly BankDepartmentManager _bankDepartmentManager;

        #endregion

        /// <summary>
        /// Событие возникающее при дейтвиях менеджера
        /// </summary>
        public event ManagerEventHandler ManagerEvent;

        /// <summary>
        /// Получить список всех клиентов
        /// </summary>
        public IList<IBankCustomer> BankCustomers => _bankCustomerRepository.GetAll();

        /// <summary>
        /// Обновление данных клиента банка и сохранение в репозитории
        /// </summary>
        /// <param name="bankCustomer"> Клиент банка </param>
        public void Update(IBankCustomer bankCustomer)
        {
            _bankCustomerRepository.Update(bankCustomer);
            ManagerEvent?.Invoke(bankCustomer, ManagerArgs.UPDATE);
        }

        /// <summary>
        /// Добавление нового клиента банка в департамент
        /// </summary>
        /// <param name="bankCustomer"> Клиент банка </param>
        /// <param name="bankDepartment"> Департамент </param>        
        public bool Create(IBankCustomer bankCustomer,
                           IBankDepartment bankDepartment)
        {
            if (bankCustomer is null)
                throw new ArgumentNullException(nameof(bankCustomer), "Добавляемый клиент банка не может быть null!!!");
            if (bankDepartment is null)
                throw new ArgumentNullException(nameof(bankDepartment), "Департамент не может быть null!!!");

            var selectedDepartment = _bankDepartmentManager.Get(bankDepartment.Name);
            if (selectedDepartment is null) return false;

            bankDepartment.BankCustomers.Add(bankCustomer);
            _bankCustomerRepository.Add(bankCustomer);
            ManagerEvent?.Invoke(bankCustomer, ManagerArgs.CREATE);

            return true;
        }

        /// <summary>
        /// Удалить клиента банка из департамента
        /// </summary>
        /// <param name="bankCustomer"> Клиент банка </param>
        /// <param name="bankDepartment"> Департамент </param>
        public bool Delete(IBankCustomer bankCustomer,
                           IBankDepartment bankDepartment)
        {
            if (bankCustomer is null)
                throw new ArgumentNullException(nameof(bankCustomer), "Добавляемый клиент банка не может быть null!!!");
            if (bankDepartment is null)
                throw new ArgumentNullException(nameof(bankDepartment), "Департамент не может быть null!!!");

            var selectedDepartment = _bankDepartmentManager.Get(bankDepartment.Name);
            if (selectedDepartment is null) return false;
            
            if(bankDepartment.BankCustomers.Remove(bankCustomer) &&
               _bankCustomerRepository.Remove(bankCustomer))
            {
                ManagerEvent?.Invoke(bankCustomer, ManagerArgs.DELETE);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Получить клиента банка по идентификатору
        /// </summary>
        /// <param name="id"> Идентификатор </param>        
        public IBankCustomer Get(ulong id) => _bankCustomerRepository.Get(id);

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="bankCustomerRepository"> Хранилище клиентов банка </param>
        /// <param name="bankDepartmentManager"> Хранилище департаментов банка </param>
        public BankCustomerManager(BankCustomerRepository bankCustomerRepository,
                                   BankDepartmentManager bankDepartmentManager)
        {
            _bankCustomerRepository = bankCustomerRepository;
            _bankDepartmentManager = bankDepartmentManager;
        }
    }
}
