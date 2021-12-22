﻿using ModelLibrary;
using TestDataProject;

namespace ServiceLibrary
{
    /// <summary>
    /// Хранилище клиентов банка
    /// </summary>
    public class BankCustomerRepository : RepositoryInMemory<IBankCustomer>
    {
        /// <summary>
        /// Констрктор по умолчанию
        /// </summary>
        public BankCustomerRepository() : base(TestData.BankCustomers) { }
        
        /// <summary>
        /// Обновление данных клиента банка
        /// </summary>
        /// <param name="source"> Новые данные клиента </param>
        /// <param name="destination"> Обновляемый клиент </param>
        protected override void Update(IBankCustomer source, IBankCustomer destination)
        {
            destination.Id = source.Id;
            destination.Blocking = source.Blocking;
            destination.Passport = source.Passport;
            destination.PhoneNumber = source.PhoneNumber;
            destination.Reliability = source.Reliability;
            destination.ClientStatus = source.ClientStatus;            
            destination.Email = source.Email;
            destination.DepositoryAccounts = source.DepositoryAccounts;
        }
    }
}
