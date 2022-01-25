using ModelLibrary;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace DialogWindowLibrary
{   
    public partial class DepositoryAccountWindow : Window
    {
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

        public DepositoryAccountWindow() => InitializeComponent();      
    }
}
