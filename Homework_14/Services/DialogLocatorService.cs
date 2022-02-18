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
        /// Сервис диалоговых окон по работе с клиентом банка
        /// </summary>
        public BankCustomerDialog BankCustomerDialog => App.Host.Services.GetRequiredService<BankCustomerDialog>();

        /// <summary>
        /// Диалоговое окно отображения депозитарных счетов
        /// </summary>
        public DepositoryAccountDialog DepositoryAccountDialog => App.Host.Services.GetRequiredService<DepositoryAccountDialog>();
    }
}
