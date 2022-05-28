using BaseClassesLibrary;
using CommandLibrary;
using Homework_14.Services;
using ServiceLibrary;
using System.Windows.Input;
using System;

namespace Homework_14.ViewModels
{
    /// <summary>
    /// Класс Модели-Представления главной страницы
    /// </summary>
    public class MainPageViewModel : BaseViewModel
    {
        #region Закрытые поля

        private PageNavigator _pageNavigator;
        private PageLocatorService _pageLocatorService;

        #endregion

        #region Команда открыть департамент с обычными клиентами

        private ICommand _usualBankDepartmentCommand = default;
        public ICommand UsualBankDepartmentCommand
        {
            get => _usualBankDepartmentCommand ??= new RelayCommand((obj) =>
            {
                _pageNavigator.CurrentPage = _pageLocatorService.UsualBankDepartmentPage;
            });
        }

        #endregion

        #region Команда открыть департамент с vip клиентами

        private ICommand _vipBankDepartmentCommand = default;
        public ICommand VipBankDepartmentCommand
        {
            get => _vipBankDepartmentCommand ??= new RelayCommand((obj) =>
            {
                _pageNavigator.CurrentPage = _pageLocatorService.VipBankDepartmentPage;
            });               
        }

        #endregion

        #region Открыть департамент по работе с юридическими лицами

        private ICommand _juridicalBankDepartmentCommand = default;
        public ICommand JuridicalBankDepartmentCommand
        {
            get => _juridicalBankDepartmentCommand ??= new RelayCommand((obj) =>
            {
                _pageNavigator.CurrentPage = _pageLocatorService.JuridicalBankDepartmentPage;
            });
        }

        #endregion

        /// <summary>
        /// Конструктор
        /// </summary>        
        public MainPageViewModel(PageNavigator pageNavigator,
                                 PageLocatorService pageLocatorService)
        {
            if(pageNavigator is null)
                throw new ArgumentNullException(nameof(pageNavigator), "Навигатор страниц не может быть null!!!");
            if(pageLocatorService is null)
                throw new ArgumentNullException(nameof(pageLocatorService), "Локатор страниц не может быть null!!!");

            _pageNavigator = pageNavigator;
            _pageLocatorService = pageLocatorService;
        }
    }
}
