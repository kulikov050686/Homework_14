using Homework_14.Pages;
using Microsoft.Extensions.DependencyInjection;

namespace Homework_14.Services
{
    /// <summary>
    /// Класс доступа к конкретным страницам
    /// </summary>
    public class PageLocatorService
    {
        /// <summary>
        /// Главная страница
        /// </summary>
        public MainPage MainPage => App.Host.Services.GetRequiredService<MainPage>();

        /// <summary>
        /// Страница департамента с обычными клиентами
        /// </summary>
        public UsualBankDepartmentPage UsualBankDepartmentPage => App.Host.Services.GetRequiredService<UsualBankDepartmentPage>();

        /// <summary>
        /// Страница департамента с vip-клиента
        /// </summary>
        public VipBankDepartmentPage VipBankDepartmentPage => App.Host.Services.GetRequiredService<VipBankDepartmentPage>();

        /// <summary>
        /// Страница департамента с юридическими лицами
        /// </summary>
        public JuridicalBankDepartmentPage JuridicalBankDepartmentPage => App.Host.Services.GetRequiredService<JuridicalBankDepartmentPage>();
    }
}
