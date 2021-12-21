using System.Windows.Controls;
using System;

namespace ServiceLibrary
{
    /// <summary>
    /// Класс сервиса навигатора страниц
    /// </summary>
    public class PageNavigator : IPageNavigator
    {
        #region Закрытые поля

        private Page _currentPage;

        #endregion

        /// <summary>
        /// Событие навигатора страниц
        /// </summary>
        public event Action<Page> PageNavigatorEvent;

        /// <summary>
        /// Текущая страница
        /// </summary>
        public Page CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                PageNavigatorEvent?.Invoke(_currentPage);
            }
        }
    }
}
