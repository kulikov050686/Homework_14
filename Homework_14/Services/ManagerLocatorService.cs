using Microsoft.Extensions.DependencyInjection;
using ServiceLibrary;

namespace Homework_14.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class ManagerLocatorService
    {
        /// <summary>
        /// 
        /// </summary>
        public BankDepartmentManager BankDepartmentManager => App.Host.Services.GetRequiredService<BankDepartmentManager>();

        /// <summary>
        /// 
        /// </summary>
        public BankCustomerManager BankCustomerManager => App.Host.Services.GetRequiredService<BankCustomerManager>();

        /// <summary>
        /// 
        /// </summary>
        public DepositoryAccountManager DepositoryAccountManager => App.Host.Services.GetRequiredService<DepositoryAccountManager>();
    }
}
