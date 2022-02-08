using CommandLibrary;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace FileDialogLibrary
{
    /// <summary>
    /// Класс диалогового окна сохранения файла
    /// </summary>
    public class SaveFileWindowDialog : Freezable
    {
        #region Путь до файла

        public static readonly DependencyProperty PathToFileProperty =
            DependencyProperty.Register(nameof(PathToFile),
                                        typeof(string),
                                        typeof(SaveFileWindowDialog),
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
                                        typeof(SaveFileWindowDialog),
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
                                       typeof(SaveFileWindowDialog),
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

        private ICommand _openDialogCommand = default;
        public ICommand OpenDialogCommand
        {
            get => _openDialogCommand ??= new RelayCommand((obj) =>
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Title = Title,
                    Filter = Filter,
                    OverwritePrompt = true
                };

                if (PathToFile is null)
                {
                    saveFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
                }
                else
                {
                    saveFileDialog.InitialDirectory = PathToFile;
                }

                if (saveFileDialog.ShowDialog() == true)
                {
                    PathToFile = saveFileDialog.FileName;
                }
            });
        }

        #endregion

        /// <summary>
        /// Возвращает новый класс реализации
        /// </summary>
        protected override Freezable CreateInstanceCore() => new SaveFileWindowDialog();
    }
}
