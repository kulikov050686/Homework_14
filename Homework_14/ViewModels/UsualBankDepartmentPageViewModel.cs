using BaseClassesLibrary;
using CommandLibrary;
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

        private ManagerLocatorService _managerLocatorService;
        private PageLocatorService _pageLocatorService;
        private PageNavigator _pageNavigator;
        private DialogLocatorService _dialogLocatorService;
        
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
                var bankCustomer = _dialogLocatorService.BankCustomerDialog.Create(_bankDepartment.StatusDepartment);
                if (bankCustomer is null) return;

                _managerLocatorService.BankCustomerManager.Create(bankCustomer, _bankDepartment);
            });
        }

        #endregion

        #region Команда редактированть клиента банка

        private ICommand _editBankCustomerCommand = default;
        public ICommand EditBankCustomerCommand
        {
            get => _editBankCustomerCommand ??= new RelayCommand((obj) =>
            {
                var bankCustomer = _dialogLocatorService.BankCustomerDialog.Edit(SelectedBankCustomer);
                if (bankCustomer is null) return;

                _managerLocatorService.BankCustomerManager.Update(bankCustomer);
            }, (obj) => SelectedBankCustomer != null);
        }

        #endregion

        #region Команда удалить клиента банка

        private ICommand _deleteBankCustomerCommand = default;
        public ICommand DeleteBankCustomerCommand
        {
            get => _deleteBankCustomerCommand ??= new RelayCommand((obj) =>
            {
                _managerLocatorService.BankCustomerManager.Delete(SelectedBankCustomer, _bankDepartment);
            }, (obj) => SelectedBankCustomer != null);
        }

        #endregion

        #region Команда депозитарные счета

        private ICommand _depositoryAccountsCommand = default;
        public ICommand DepositoryAccountsCommand
        {
            get => _depositoryAccountsCommand ??= new RelayCommand((obj) =>
            {
                _dialogLocatorService.DepositoryAccountDialog.OpenDialog(SelectedBankCustomer);
            }, (obj) => SelectedBankCustomer != null);
        }


        #endregion

        #region Конструктор

        public UsualBankDepartmentPageViewModel(ManagerLocatorService managerLocatorService,
                                                PageLocatorService pageLocatorService,
                                                PageNavigator pageNavigator,
                                                DialogLocatorService dialogLocatorService)
        {
            _managerLocatorService = managerLocatorService;
            _pageLocatorService = pageLocatorService;
            _pageNavigator = pageNavigator;
            _dialogLocatorService = dialogLocatorService;            

            _bankDepartment = _managerLocatorService.BankDepartmentManager.Departments[0];
        }

        #endregion
    }
}
