using BaseClassesLibrary;
using EnumLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ModelLibrary
{
    /// <summary>
    /// Класс Клиент Банка
    /// </summary>
    public class BankCustomer : BaseModel, IBankCustomer
    {
        #region Закрытые поля

        private ulong _id = 0;
        private bool _blocking = false;
        private IPassport _passport = null;
        private Status _clientStatus = Status.USUAL;
        private Reliability _reliability = Reliability.FIRST;
        private string _phoneNumber = null;
        private string _email = null;
        private IList<IDepositoryAccount> _depositoryAccounts = null;
        
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
        /// Блокировка
        /// </summary>
        public bool Blocking
        {
            get => _blocking;
            set => Set(ref _blocking, value);
        }

        /// <summary>
        /// Паспорт
        /// </summary>
        public IPassport Passport
        {
            get => _passport;
            set
            {
                if (value is null)
                    throw new ArgumentNullException("Паспорт не может быть null!!!");

                Set(ref _passport, value);
            }
        }

        /// <summary>
        /// Статус
        /// </summary>
        public Status ClientStatus
        {
            get => _clientStatus;
            set => Set(ref _clientStatus, value);
        }

        /// <summary>
        /// Надёжность
        /// </summary>
        public Reliability Reliability
        {
            get => _reliability;
            set => Set(ref _reliability, value);
        }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Номер телефона не может быть пустым или null");

                Set(ref _phoneNumber, value);
            }
        }

        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        public string Email
        {
            get => _email;
            set => Set(ref _email, value);
        }

        /// <summary>
        /// Лист депозитарных счетов
        /// </summary>
        public IList<IDepositoryAccount> DepositoryAccounts
        {
            get => _depositoryAccounts;
            set => Set(ref _depositoryAccounts, value);
        } 

        /// <summary>
        /// Количество депозитарных счетов
        /// </summary>
        public int DepositoryAccountCount
        {
            get
            {
                if (DepositoryAccounts is null) return 0;
                return DepositoryAccounts.Count;
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id"> Идентификатор </param>
        /// <param name="passport"> Паспорт </param>
        /// <param name="clientStatus"> Статус </param>
        /// <param name="reliability"> Надёжность </param>
        /// <param name="phoneNumber"> Номер телефон </param>
        /// <param name="email"> Электронная почта </param>
        public BankCustomer(ulong id,
                            IPassport passport,
                            Status clientStatus,
                            Reliability reliability,
                            string phoneNumber,
                            string email = null)
        {
            Id = id;
            Passport = passport;
            ClientStatus = clientStatus;
            Reliability = reliability;
            PhoneNumber = phoneNumber;
            Email = email;
            DepositoryAccounts = new ObservableCollection<IDepositoryAccount>();
        }
    }
}
