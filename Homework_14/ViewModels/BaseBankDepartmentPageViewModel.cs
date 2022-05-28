using BaseClassesLibrary;
using CommandLibrary;
using EnumLibrary;
using Homework_14.Services;
using ModelLibrary;
using ServiceLibrary;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Homework_14.ViewModels
{
    /// <summary>
    /// Абстрактный базовый класс модели-представления страницы 
    /// </summary>
    public abstract class BaseBankDepartmentPageViewModel : BaseViewModel
    {
        #region Закрытые поля

        protected ManagerLocatorService _managerLocatorService;
        protected PageLocatorService _pageLocatorService;
        protected PageNavigator _pageNavigator;
        protected DialogLocatorService _dialogLocatorService;
        protected IBankDepartment _bankDepartment;

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

        #region Команда добавить клиента банка

        private ICommand _addBankCustomerCommand = default;
        public ICommand AddBankCustomerCommand
        {
            get => _addBankCustomerCommand ??= new RelayCommand((obj) =>
            {
                try
                {
                    var bankCustomer = _dialogLocatorService.BankCustomerDialog.Create(_bankDepartment.StatusDepartment);
                    if (bankCustomer is null) return;

                    _managerLocatorService.BankCustomerManager.Create(bankCustomer, _bankDepartment);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, 
                                    "Ошибка!!!", 
                                    MessageBoxButton.OK, 
                                    MessageBoxImage.Error);
                }
            });
        }

        #endregion

        #region Команда редактированть клиента банка

        private ICommand _editBankCustomerCommand = default;
        public ICommand EditBankCustomerCommand
        {
            get => _editBankCustomerCommand ??= new RelayCommand((obj) =>
            {
                try
                {
                    var bankCustomer = _dialogLocatorService.BankCustomerDialog.Edit(SelectedBankCustomer);
                    if (bankCustomer is null) return;

                    _managerLocatorService.BankCustomerManager.Update(bankCustomer);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                                    "Ошибка!!!",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                }               
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

        public BaseBankDepartmentPageViewModel(ManagerLocatorService managerLocatorService,
                                               PageLocatorService pageLocatorService,
                                               PageNavigator pageNavigator,
                                               DialogLocatorService dialogLocatorService,
                                               BankDepartmentPage bankDepartmentPage)
        {
            if(managerLocatorService is null)
                throw new ArgumentNullException(nameof(managerLocatorService), "Локатор менеджеров не может быть null!!!");            
            if(pageLocatorService is null)
                throw new ArgumentNullException(nameof(pageLocatorService), "Локатор страниц не может быть null!!!");
            if(pageNavigator is null)
                throw new ArgumentNullException(nameof(pageNavigator), "Навигатор страниц не может быть null!!!");
            if(dialogLocatorService is null)
                throw new ArgumentNullException(nameof(dialogLocatorService), "Локатор диалоговых окон не может быть null!!!");

            _managerLocatorService = managerLocatorService;
            _pageLocatorService = pageLocatorService;
            _pageNavigator = pageNavigator;
            _dialogLocatorService = dialogLocatorService;

            switch (bankDepartmentPage)
            {
                case BankDepartmentPage.USUAL:
                    _bankDepartment = _managerLocatorService.BankDepartmentManager.Departments[0];
                    break;
                case BankDepartmentPage.VIP:
                    _bankDepartment = _managerLocatorService.BankDepartmentManager.Departments[1];
                    break;
                case BankDepartmentPage.JURIDICAL:
                    _bankDepartment = _managerLocatorService.BankDepartmentManager.Departments[2];
                    break;
                default:
                    throw new ArgumentException("Ошибка страницы!!!");
            }
        }

        #endregion
    }
}
