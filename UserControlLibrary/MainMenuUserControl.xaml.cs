using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace UserControlLibrary
{
    public partial class MainMenuUserControl : UserControl
    {
        #region Родительское окно

        public static readonly DependencyProperty ParentWindowUCProperty =
           DependencyProperty.Register(nameof(ParentWindowUC),
                                       typeof(Window),
                                       typeof(MainMenuUserControl),
                                       new PropertyMetadata(default(Window)));

        /// <summary>
        /// Родительское окно
        /// </summary>
        [Description("Родительское окно")]
        public Window ParentWindowUC
        {
            get => (Window)GetValue(ParentWindowUCProperty);
            set => SetValue(ParentWindowUCProperty, value);
        }

        #endregion

        public MainMenuUserControl() => InitializeComponent();        
    }
}
