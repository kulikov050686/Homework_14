using DialogLibrary;
using FileIOLibrary;
using Homework_14.Pages;
using Homework_14.Services;
using Homework_14.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using ModelLibrary;
using ServiceLibrary;

namespace Homework_14
{
    /// <summary>
    /// Класс регистрации
    /// </summary>
    public static class Registrator
    {
        /// <summary>
        /// Регистрация всех сервисов
        /// </summary>              
        public static IServiceCollection RegisterServices(this IServiceCollection services) => services
            .AddSingleton<BankDepartmentRepository>()
            .AddSingleton<BankCustomerRepository>()
            .AddSingleton<DepositoryAccountRepository>()
            .AddSingleton<PageNavigator>()
            .AddTransient<BankDepartmentManager>()
            .AddTransient<BankCustomerManager>()
            .AddTransient<DepositoryAccountManager>()
            .AddTransient<PageLocatorService>()
            .AddTransient<ManagerLocatorService>()
            .AddTransient<EntityCreator>()
            .AddTransient<DepartmentJSONFileIOService>()
            .AddTransient<ProcessingOfDepositoryAccounts>()
        ;        

        /// <summary>
        /// Регистрация всех моделей-представления
        /// </summary>           
        public static IServiceCollection RegisterViewModels(this IServiceCollection services) => services
            .AddSingleton<MainWindowViewModel>()
            .AddTransient<MainPageViewModel>()
            .AddTransient<UsualBankDepartmentPageViewModel>()
            .AddTransient<VipBankDepartmentPageViewModel>()
            .AddTransient<JuridicalBankDepartmentPageViewModel>()
            .AddTransient<MainMenuViewModel>()
        ;        

        /// <summary>
        /// Регистрация всех страниц
        /// </summary>            
        public static IServiceCollection RegisterPages(this IServiceCollection services) => services
            .AddTransient<MainPage>()
            .AddTransient<UsualBankDepartmentPage>()
            .AddTransient<VipBankDepartmentPage>()
            .AddTransient<JuridicalBankDepartmentPage>()
        ;        

        /// <summary>
        /// Регистрация всех диалоговых окон
        /// </summary>        
        public static IServiceCollection RegisterDialogWindows(this IServiceCollection services) => services
            .AddTransient<DialogWindowsLocator>()
            .AddTransient<BankCustomerDialog>()
            .AddTransient<DepositoryAccountDialog>()
            .AddTransient<DialogLocatorService>()
        ;       
    }
}
