using Microsoft.Extensions.DependencyInjection;
using ServiceLibrary;

namespace Homework_14.Services
{
    /// <summary>
    /// Класс доступа к конкретным менеджерам
    /// </summary>
    public class ManagerLocatorService
    {
        /// <summary>
        /// Менеждер отделов банка
        /// </summary>
        public BankDepartmentManager BankDepartmentManager => App.Host.Services.GetRequiredService<BankDepartmentManager>();

        /// <summary>
        /// Менеджер клиентов банка
        /// </summary>
        public BankCustomerManager BankCustomerManager => App.Host.Services.GetRequiredService<BankCustomerManager>();

        /// <summary>
        /// Менеджер депозитарных счетов
        /// </summary>
        public DepositoryAccountManager DepositoryAccountManager => App.Host.Services.GetRequiredService<DepositoryAccountManager>();
    }
}
