﻿using Homework_14.Services;
using ServiceLibrary;
using System.Windows.Controls;

namespace Homework_14.ViewModels
{
    /// <summary>
    /// Модель-Представление главного окна
    /// </summary>
    public class MainWindowViewModel : BaseClassViewModelINPC
    {
        #region Закрытые поля

        private Page _currentPage;
        private PageNavigator _pageNavigator;
        private PageLocatorService _pageLocatorService;

        #endregion

        /// <summary>
        /// Название окна
        /// </summary>
        public string Title { get; protected set; }

        /// <summary>
        /// Текущая страница
        /// </summary>
        public Page CurrentPage
        {
            get => _currentPage;
            set => Set(ref _currentPage, value);
        }

        #region Конструктор

        public MainWindowViewModel(PageNavigator pageNavigatorService,
                                   PageLocatorService pageLocatorService)
        {
            Title = "Банк";

            _pageNavigator = pageNavigatorService;
            _pageLocatorService = pageLocatorService;
            CurrentPage = pageLocatorService.MainPage;

            _pageNavigator.PageNavigatorEvent += OnPageNavigatorEvent;
        }

        #endregion

        private void OnPageNavigatorEvent(Page obj)
        {
            CurrentPage = obj;
        }
    }
}
