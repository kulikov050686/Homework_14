using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

        #region Команда открытия файла

        public static readonly DependencyProperty OpenFileCommandUCProperty =
           DependencyProperty.Register(nameof(OpenFileCommandUC),
                                       typeof(ICommand),
                                       typeof(MainMenuUserControl),
                                       new PropertyMetadata(default(ICommand)));

        /// <summary>
        /// Команда открытия файла
        /// </summary>
        [Description("Команда открытия файла")]
        public ICommand OpenFileCommandUC
        {
            get => (ICommand)GetValue(OpenFileCommandUCProperty);
            set => SetValue(OpenFileCommandUCProperty, value);
        }

        #endregion

        #region Параметр команды открытия файла

        public static readonly DependencyProperty OpenFileCommandParameterUCProperty =
           DependencyProperty.Register(nameof(OpenFileCommandParameterUC),
                                       typeof(object),
                                       typeof(MainMenuUserControl),
                                       new PropertyMetadata(default(object)));

        /// <summary>
        /// Параметр команды открытия файла
        /// </summary>
        [Description("Параметр команды открытия файла")]
        public object OpenFileCommandParameterUC
        {
            get => GetValue(OpenFileCommandParameterUCProperty);
            set => SetValue(OpenFileCommandParameterUCProperty, value);
        }

        #endregion

        #region Команда сохранения файла

        public static readonly DependencyProperty SaveFileCommandUCProperty =
           DependencyProperty.Register(nameof(SaveFileCommandUC),
                                       typeof(ICommand),
                                       typeof(MainMenuUserControl),
                                       new PropertyMetadata(default(ICommand)));

        /// <summary>
        /// Команда сохранения файла
        /// </summary>
        [Description("Команда сохранения файла")]
        public ICommand SaveFileCommandUC
        {
            get => (ICommand)GetValue(SaveFileCommandUCProperty);
            set => SetValue(SaveFileCommandUCProperty, value);
        }

        #endregion

        #region Параметр команды сохранения в файл

        public static readonly DependencyProperty SaveFileCommandParameterUCProperty =
           DependencyProperty.Register(nameof(SaveFileCommandParameterUC),
                                       typeof(object),
                                       typeof(MainMenuUserControl),
                                       new PropertyMetadata(default(object)));

        /// <summary>
        /// Параметр команды сохранения в файл
        /// </summary>
        [Description("Параметр команды сохранения в файл")]
        public object SaveFileCommandParameterUC
        {
            get => GetValue(SaveFileCommandParameterUCProperty);
            set => SetValue(SaveFileCommandParameterUCProperty, value);
        }

        #endregion

        #region Путь до файла

        public static readonly DependencyProperty PathToFileUCProperty =
           DependencyProperty.Register(nameof(PathToFileUC),
                                       typeof(string),
                                       typeof(MainMenuUserControl),
                                       new PropertyMetadata(default(string)));

        /// <summary>
        /// Путь до файла
        /// </summary>
        [Description("Путь до файла")]
        public string PathToFileUC
        {
            get => (string)GetValue(PathToFileUCProperty);
            set => SetValue(PathToFileUCProperty, value);
        }

        #endregion

        #region Фильтр расширений файлов

        public static readonly DependencyProperty FilterUCProperty =
           DependencyProperty.Register(nameof(FilterUC),
                                       typeof(string),
                                       typeof(MainMenuUserControl),
                                       new PropertyMetadata("Все файлы (*.*)|*.*"));

        /// <summary>
        /// Фильтр расширений файлов
        /// </summary>
        [Description("Фильтр расширений файлов")]
        public string FilterUC
        {
            get => (string)GetValue(FilterUCProperty);
            set => SetValue(FilterUCProperty, value);
        }

        #endregion

        public MainMenuUserControl() => InitializeComponent();        
    }
}
