using CommandLibrary;
using Homework_14.Services;
using Microsoft.Extensions.DependencyInjection;
using ModelLibrary;
using ServiceLibrary;
using System.Collections.Generic;
using System.Windows.Input;

namespace Homework_14.ViewModels
{
    /// <summary>
    /// Модель-Представление страницы департамента с vip клиентами
    /// </summary>
    public class VipBankDepartmentPageViewModel : BaseClassViewModelINPC
    {
        #region Закрытые поля
                
        private BankDepartmentRepository _bankDepartmentRepository;
        private PageLocatorService _pageLocatorService;
        private PageNavigator _pageNavigator;

        private IBankDepartment _bankDepartment;
        private IBankCustomer _selectedBankCustomer;

        #endregion

        /// <summary>
        /// Имя департамента
        /// </summary>
        public string NameDepartment => _bankDepartment.Name;

        /// <summary>
        /// Список всех клиентов банка
        /// </summary>
        public IList<IBankCustomer> BankCustomers => _bankDepartment.BankCustomers;

        /// <summary>
        /// Выбранный клиент
        /// </summary>
        public IBankCustomer SelectedBankCustomer
        {
            get => _selectedBankCustomer;
            set => Set(ref _selectedBankCustomer, value);
        }

        #region Команда вернуться на главную страницу

        private ICommand _mainPageCommand = default;
        public ICommand MainPageCommand
        {
            get => _mainPageCommand ??= new RelayCommand((obj) =>
            {
                _pageNavigator.CurrentPage = _pageLocatorService.MainPage;
            });
        }

        #endregion

        #region Конструктор

        public VipBankDepartmentPageViewModel()
        {
            _bankDepartmentRepository = App.Host.Services.GetRequiredService<BankDepartmentRepository>();
            _pageLocatorService = App.Host.Services.GetRequiredService<PageLocatorService>();
            _pageNavigator = App.Host.Services.GetRequiredService<PageNavigator>();

            _bankDepartment = _bankDepartmentRepository.GetAll()[1];
        }

        #endregion
    }
}
