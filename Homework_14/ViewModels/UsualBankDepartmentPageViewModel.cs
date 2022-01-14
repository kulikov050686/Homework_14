using BaseClassesLibrary;
using CommandLibrary;
using DialogLibrary;
using EnumLibrary;
using Homework_14.Services;
using ModelLibrary;
using ServiceLibrary;
using System.Collections.Generic;
using System.Windows.Input;

namespace Homework_14.ViewModels
{
    /// <summary>
    /// Модель-Представление страницы департамента с обычными клиентами
    /// </summary>
    public class UsualBankDepartmentPageViewModel : BaseViewModel
    {
        #region Закрытые поля
               
        private BankDepartmentManager _bankDepartmentManager;
        private PageLocatorService _pageLocatorService;
        private PageNavigator _pageNavigator;
        private BankCustomerDialog _bankCustomerDialog;
        private BankCustomerManager _bankCustomerManager;

        private IBankDepartment _bankDepartment;
        private IBankCustomer _selectedBankCustomer;

        #endregion

        /// <summary>
        /// Статус
        /// </summary>
        public Status Status => _bankDepartment.StatusDepartment;

        /// <summary>
        /// Имя департамента
        /// </summary>
        public string NameDepartment => _bankDepartment.Name;

        /// <summary>
        /// Список всех клиентов банка
        /// </summary>
        public IEnumerable<IBankCustomer> BankCustomers => _bankDepartment.BankCustomers;

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

        #region Команда добавить клиента банка

        private ICommand _addBankCustomerCommand = default;
        public ICommand AddBankCustomerCommand
        {
            get => _addBankCustomerCommand ??= new RelayCommand((obj) => 
            {
                var bankCustomer = _bankCustomerDialog.Create(_bankDepartment.StatusDepartment);
                if (bankCustomer is null) return;

                _bankCustomerManager.Create(bankCustomer, _bankDepartment);
            });
        }

        #endregion

        #region Команда редактированть клиента банка

        private ICommand _editBankCustomerCommand = default;
        public ICommand EditBankCustomerCommand
        {
            get => _editBankCustomerCommand ??= new RelayCommand((obj) =>
            {
                var bankCustomer = _bankCustomerDialog.Edit(SelectedBankCustomer);
                if (bankCustomer is null) return;

                _bankCustomerManager.Update(bankCustomer);
            }, (obj) => SelectedBankCustomer != null);
        }

        #endregion

        #region Команда удалить клиента банка

        private ICommand _deleteBankCustomerCommand = default;
        public ICommand DeleteBankCustomerCommand
        {
            get => _deleteBankCustomerCommand ??= new RelayCommand((obj) =>
            {
                _bankCustomerManager.Delete(SelectedBankCustomer, _bankDepartment);
            }, (obj) => SelectedBankCustomer != null);
        }

        #endregion

        #region Конструктор

        public UsualBankDepartmentPageViewModel(BankDepartmentManager bankDepartmentManager,
                                                PageLocatorService pageLocatorService,
                                                PageNavigator pageNavigator,
                                                BankCustomerDialog bankCustomerDialog,
                                                BankCustomerManager bankCustomerManager)
        {
            _bankDepartmentManager = bankDepartmentManager;
            _pageLocatorService = pageLocatorService;
            _pageNavigator = pageNavigator;
            _bankCustomerDialog = bankCustomerDialog;
            _bankCustomerManager = bankCustomerManager;

            _bankDepartment = _bankDepartmentManager.Departments[0];
        }

        #endregion
    }
}
