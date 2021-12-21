using System;
using System.Windows.Controls;

namespace ServiceLibrary
{    
    /// <summary>
    /// Интерфейс навигатора страниц
    /// </summary>
    public interface IPageNavigator
    {
        /// <summary>
        /// Событие навигатора страниц
        /// </summary>
        public event Action<Page> PageNavigatorEvent;

        /// <summary>
        /// Текущая страница
        /// </summary>
        public Page CurrentPage { get; set; }
    }
}
