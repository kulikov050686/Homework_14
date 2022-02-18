using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UserControlLibrary
{
    public partial class PhotoUserControl : UserControl
    {
        #region Название

        public static readonly DependencyProperty TitleUCProperty =
           DependencyProperty.Register(nameof(TitleUC),
                                       typeof(string),
                                       typeof(PhotoUserControl),
                                       new PropertyMetadata(default(string)));

        /// <summary>
        /// Название
        /// </summary>
        [Description("Название")]
        public string TitleUC
        {
            get => (string)GetValue(TitleUCProperty);
            set => SetValue(TitleUCProperty, value);
        }

        #endregion

        #region Команда открытия файла

        public static readonly DependencyProperty OpenFileCommandUCProperty =
           DependencyProperty.Register(nameof(OpenFileCommandUC),
                                       typeof(ICommand),
                                       typeof(PhotoUserControl),
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

        #region Путь до файла картинки

        public static readonly DependencyProperty PathToImageFileUCProperty =
           DependencyProperty.Register(nameof(PathToImageFileUC),
                                       typeof(string),
                                       typeof(PhotoUserControl),
                                       new PropertyMetadata(default(string)));

        /// <summary>
        /// Путь до файла картинки
        /// </summary>
        [Description("Путь до файла картинки")]
        public string PathToImageFileUC
        {
            get => (string)GetValue(PathToImageFileUCProperty);
            set => SetValue(PathToImageFileUCProperty, value);
        }

        #endregion

        #region Текст на кнопке

        public static readonly DependencyProperty TextOnButtonUCProperty =
           DependencyProperty.Register(nameof(TextOnButtonUC),
                                       typeof(string),
                                       typeof(PhotoUserControl),
                                       new PropertyMetadata(default(string)));

        /// <summary>
        /// Текст на кнопке
        /// </summary>
        [Description("Текст на кнопке")]
        public string TextOnButtonUC
        {
            get => (string)GetValue(TextOnButtonUCProperty);
            set => SetValue(TextOnButtonUCProperty, value);
        }

        #endregion

        public PhotoUserControl() => InitializeComponent();        
    }
}
