using DialogLibrary;
using Microsoft.Extensions.DependencyInjection;

namespace Homework_14.Services
{
    /// <summary>
    /// Класс доступа к конкретным диалоговым окнам
    /// </summary>
    public class DialogLocatorService
    {
        /// <summary>
        /// 
        /// </summary>
        public BankCustomerDialog BankCustomerDialog => App.Host.Services.GetRequiredService<BankCustomerDialog>();

        /// <summary>
        /// 
        /// </summary>
        public DepositoryAccountDialog DepositoryAccountDialog => App.Host.Services.GetRequiredService<DepositoryAccountDialog>();
    }
}
