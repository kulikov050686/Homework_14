using CommandLibrary;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace DialogWindowLibrary
{
    /// <summary>
    /// Класс диалогового окна сохранения или открытия файла
    /// </summary>
    public class OpenDialog : Freezable
    {
        #region Путь до файла

        public static readonly DependencyProperty PathToFileProperty =
            DependencyProperty.Register(nameof(PathToFile),
                                        typeof(string),
                                        typeof(OpenDialog),
                                        new PropertyMetadata(default(string)));

        /// <summary>
        /// Путь до файла
        /// </summary>
        [Description("Путь до файла")]
        public string PathToFile
        {
            get => (string)GetValue(PathToFileProperty);
            set => SetValue(PathToFileProperty, value);
        }

        #endregion

        #region Название окна

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(nameof(Title),
                                        typeof(string),
                                        typeof(OpenDialog),
                                        new PropertyMetadata(default(string)));

        /// <summary>
        /// Название окна
        /// </summary>
        [Description("Название окна")]
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        #endregion

        #region Фильтр расширений файлов

        public static readonly DependencyProperty FilterProperty =
           DependencyProperty.Register(nameof(Filter),
                                       typeof(string),
                                       typeof(OpenDialog),
                                       new PropertyMetadata("Все файлы (*.*)|*.*"));

        /// <summary>
        /// Фильтр расширений файлов
        /// </summary>
        [Description("Фильтр расширений файлов")]
        public string Filter
        {
            get => (string)GetValue(FilterProperty);
            set => SetValue(FilterProperty, value);
        }

        #endregion

        #region Комманда открыть диалог

        private ICommand _openCommand = default;
        public ICommand OpenCommand
        {
            get => _openCommand ??= new RelayCommand((obj) =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Title = Title,
                    Filter = Filter
                };

                if (PathToFile is null)
                {
                    openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
                }
                else
                {
                    openFileDialog.InitialDirectory = PathToFile;
                }

                if (openFileDialog.ShowDialog() == true)
                {
                    PathToFile = openFileDialog.FileName;
                }
            });
        }

        #endregion

        /// <summary>
        /// Возвращает новый класс реализации
        /// </summary>        
        protected override Freezable CreateInstanceCore() => new OpenDialog();
    }
}
