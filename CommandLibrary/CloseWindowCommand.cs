﻿using System.Windows;

namespace CommandLibrary
{
    /// <summary>
    /// Класс команда закрытия окна
    /// </summary>
    public class CloseWindowCommand : BaseCommand
    {
        public override bool CanExecute(object parameter) => parameter is Window;        

        public override void Execute(object parameter)
        {
            if (!CanExecute(parameter)) return;

            var window = (Window)parameter;
            window.Close();
        }
    }
}
