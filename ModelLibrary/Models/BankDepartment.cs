using BaseClassesLibrary;
using EnumLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ModelLibrary
{
    /// <summary>
    /// Класс департамент банка
    /// </summary>
    public class BankDepartment : BaseModel, IBankDepartment
    {
        #region Закрытые поля

        private ulong _id;
        private string _name;
        private Status _statusDepartment;
        private IList<IBankCustomer> _bankCustomers;

        #endregion

        /// <summary>
        /// Идентификатор
        /// </summary>
        public ulong Id
        {
            get => _id;
            set => Set(ref _id, value);
        }
        
        /// <summary>
        /// Название
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Название департамента не может быть тустым или null!!!");
                Set(ref _name, value);
            }
        }

        /// <summary>
        /// Статус департамента
        /// </summary>
        public Status StatusDepartment
        {
            get => _statusDepartment;
            set => Set(ref _statusDepartment, value);
        }

        /// <summary>
        /// Лист клиентов банка
        /// </summary>
        public IList<IBankCustomer> BankCustomers
        {
            get => _bankCustomers;
            set => Set(ref _bankCustomers, value);
        }

        /// <summary>
        /// Количество клиентов банка
        /// </summary>
        public int BankCustomerCount
        {
            get
            {
                if(BankCustomers is null) return 0;
                return BankCustomers.Count;
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id"> Идентификатор </param>
        /// <param name="name"> Название </param>
        /// <param name="statusDepartment"> Статус </param>
        public BankDepartment(ulong id,
                              string name,
                              Status statusDepartment)
        {
            Id = id;
            Name = name;
            StatusDepartment = statusDepartment;
            BankCustomers = new ObservableCollection<IBankCustomer>();
        }
    }
}
