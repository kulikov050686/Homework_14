using ModelLibrary;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System;
using CommandLibrary;

namespace DialogLibrary
{
    /// <summary>
    /// Окно отображения депозитарных счетов клиента банка
    /// </summary>
    public partial class DepositoryAccountWindow : Window
    {
        #region События возникающие при манитуляциях со счетами

        /// <summary>
        /// Событие возникающее при удалении депозитарного счёта
        /// </summary>
        public event Action<object> DeleteDepositoryAccount;

        /// <summary>
        /// Событие возникающее при создании депозитарного счёта
        /// </summary>
        public event Action CreateDepositoryAccount;

        /// <summary>
        /// Событие возникающее при редактировании депозитарного счёта
        /// </summary>
        public event Action<object> EditDepositoryAccount;

        #endregion

        #region Список депозитарных счетов

        public static readonly DependencyProperty DepositoryAccountsProperty =
            DependencyProperty.Register(nameof(DepositoryAccounts),
                                        typeof(IEnumerable<IDepositoryAccount>),
                                        typeof(DepositoryAccountWindow),
                                        new PropertyMetadata(default(IEnumerable<IDepositoryAccount>)));

        /// <summary>
        /// Список депозитарных счетов
        /// </summary>
        [Description("Список депозитарных счетов")]
        public IEnumerable<IDepositoryAccount> DepositoryAccounts
        {
            get => (IEnumerable<IDepositoryAccount>)GetValue(DepositoryAccountsProperty);
            set => SetValue(DepositoryAccountsProperty, value);
        }

        #endregion

        #region Выбор депозитарного счита

        public static readonly DependencyProperty SelectedDepositoryAccountProperty =
            DependencyProperty.Register(nameof(SelectedDepositoryAccount),
                                        typeof(IDepositoryAccount),
                                        typeof(DepositoryAccountWindow),
                                        new PropertyMetadata(default(IDepositoryAccount)));

        /// <summary>
        /// Выбор депозитарного счита
        /// </summary>
        [Description("Выбор депозитарного счита")]
        public IDepositoryAccount SelectedDepositoryAccount
        {
            get => (IDepositoryAccount)GetValue(SelectedDepositoryAccountProperty);
            set => SetValue(SelectedDepositoryAccountProperty, value);
        }

        #endregion

        #region Команда удалить депозитарный счёт

        private ICommand _deleteDepositoryAccountCommand = default;
        public ICommand DeleteDepositoryAccountCommand
        {
            get => _deleteDepositoryAccountCommand ??= new RelayCommand((obj) =>
            {
                DeleteDepositoryAccount?.Invoke(SelectedDepositoryAccount);
            }, (obj) => SelectedDepositoryAccount != null);             
        }

        #endregion

        #region Комманда создать депозитарный счёт

        private ICommand _createDepositoryAccountCommand = default;
        public ICommand CreateDepositoryAccountCommand
        {
            get => _createDepositoryAccountCommand ??= new RelayCommand((obj) =>
            {
                CreateDepositoryAccount?.Invoke();
            });
        }

        #endregion

        #region Комманда редактировать депозитарный счёт

        private ICommand _editDepositoryAccountCommand = default;
        public ICommand EditDepositoryAccountCommand
        {
            get => _editDepositoryAccountCommand ??= new RelayCommand((obj) =>
            {
                EditDepositoryAccount?.Invoke(SelectedDepositoryAccount);
            }, (obj) => SelectedDepositoryAccount != null);
        }

        #endregion

        public DepositoryAccountWindow() => InitializeComponent();      
    }
}
