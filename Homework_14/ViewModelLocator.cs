using Homework_14.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Homework_14
{
    /// <summary>
    /// Класс доступа к конкретным Моделям-Представления
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Модель-Представление главного окна
        /// </summary>
        public MainWindowViewModel MainWindowVM => App.Host.Services.GetRequiredService<MainWindowViewModel>();

        /// <summary>
        /// Модель-Представление главной страницы
        /// </summary>
        public MainPageViewModel MainPageVM => App.Host.Services.GetRequiredService<MainPageViewModel>();

        /// <summary>
        /// Модель-Представление страницы департамента с обычными клиентами 
        /// </summary>
        public UsualBankDepartmentPageViewModel UsualBankDepartmentPageVM => App.Host.Services.GetRequiredService<UsualBankDepartmentPageViewModel>();

        /// <summary>
        /// Модель-Представление страницы департамента с vip клиентами 
        /// </summary>
        public VipBankDepartmentPageViewModel VipBankDepartmentPageVM => App.Host.Services.GetRequiredService<VipBankDepartmentPageViewModel>();

        /// <summary>
        /// Модель-Представление страницы департамента с юридическими лицами 
        /// </summary>
        public JuridicalBankDepartmentPageViewModel JuridicalBankDepartmentPageVM => App.Host.Services.GetRequiredService<JuridicalBankDepartmentPageViewModel>();
    }
}
