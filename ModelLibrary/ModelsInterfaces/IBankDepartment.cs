using EnumLibrary;
using System.Collections.Generic;

namespace ModelLibrary
{
    /// <summary>
    /// Интерфейс департамент
    /// </summary>    
    public interface IBankDepartment : IEntity
    {
        /// <summary>
        /// Название
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Статус департамента
        /// </summary>
        Status StatusDepartment { get; set; }

        /// <summary>
        /// Лист клиентов банка
        /// </summary>
        IList<IBankCustomer> BankCustomers { get; set; }

        /// <summary>
        /// Количество клиентов банка
        /// </summary>
        int BankCustomerCount { get; }
    }
}
