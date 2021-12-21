using Homework_14.Pages;
using Homework_14.Services;
using Homework_14.ViewModels;
using Microsoft.Extensions.DependencyInjection;
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
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<BankDepartmentRepository>();
            services.AddSingleton<PageNavigator>();

            services.AddTransient<PageLocatorService>();
            return services;
        }

        /// <summary>
        /// Регистрация всех моделей-представления
        /// </summary>           
        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();

            services.AddTransient<MainPageViewModel>();
            services.AddTransient<UsualBankDepartmentPageViewModel>();
            services.AddTransient<VipBankDepartmentPageViewModel>();
            services.AddTransient<JuridicalBankDepartmentPageViewModel>();

            return services;
        }

        /// <summary>
        /// Регистрация всех страниц
        /// </summary>            
        public static IServiceCollection RegisterPages(this IServiceCollection services)
        {
            services.AddTransient<MainPage>();
            services.AddTransient<UsualBankDepartmentPage>();
            services.AddTransient<VipBankDepartmentPage>();
            services.AddTransient<JuridicalBankDepartmentPage>();

            return services;
        }
    }
}
