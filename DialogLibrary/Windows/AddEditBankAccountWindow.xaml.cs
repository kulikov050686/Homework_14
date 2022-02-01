﻿using EnumLibrary;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace DialogLibrary
{
    public partial class AddEditBankAccountWindow : Window
    {
        #region Сумма

        public static readonly DependencyProperty AmountProperty =
            DependencyProperty.Register(nameof(Amount),
                                        typeof(double?),
                                        typeof(AddEditBankAccountWindow),
                                        new PropertyMetadata(default(double?)));

        /// <summary>
        /// Сумма
        /// </summary>
        [Description("Сумма")]
        public double? Amount
        {
            get => (double?)GetValue(AmountProperty);
            set => SetValue(AmountProperty, value);
        }

        #endregion

        #region Процентная ставка

        public static readonly DependencyProperty InterestRateProperty =
            DependencyProperty.Register(nameof(InterestRate),
                                        typeof(double?),
                                        typeof(AddEditBankAccountWindow),
                                        new PropertyMetadata(default(double?)));

        /// <summary>
        /// Процентная ставка
        /// </summary>
        [Description("Процентная ставка")]
        public double? InterestRate
        {
            get => (double?)GetValue(InterestRateProperty);
            set => SetValue(InterestRateProperty, value);
        }

        #endregion

        #region Лист Статусов депозита

        [Description("Лист Статусов депозита")]
        public List<string> DepositStatusList { get; set; } = new List<string> { "Без капитализации", "С капитализацией" };

        #endregion

        #region Выбор статуса депозита

        public static readonly DependencyProperty SelectedDepositStatusProperty =
            DependencyProperty.Register(nameof(SelectedDepositStatus),
                                        typeof(DepositStatus),
                                        typeof(AddEditBankAccountWindow),
                                        new PropertyMetadata(default(DepositStatus)));

        /// <summary>
        /// Выбор статуса депозита
        /// </summary>
        [Description("Выбор статуса депозита")]
        public DepositStatus SelectedDepositStatus
        {
            get => (DepositStatus)GetValue(SelectedDepositStatusProperty);
            set => SetValue(SelectedDepositStatusProperty, value);
        }

        #endregion

        #region Отображение поля для ввода суммы

        public static readonly DependencyProperty AmountVisibilityProperty =
            DependencyProperty.Register(nameof(AmountVisibility),
                                        typeof(Visibility),
                                        typeof(AddEditBankAccountWindow),
                                        new PropertyMetadata(Visibility.Visible));

        /// <summary>
        /// Отображение поля для ввода суммы
        /// </summary>
        [Description("Отображение поля для ввода суммы")]
        public Visibility AmountVisibility
        {
            get => (Visibility)GetValue(AmountVisibilityProperty);
            set => SetValue(AmountVisibilityProperty, value);
        }

        #endregion

        #region Отображение поля для ввода процентной ставки

        public static readonly DependencyProperty InterestRateVisibilityProperty =
            DependencyProperty.Register(nameof(InterestRateVisibility),
                                        typeof(Visibility),
                                        typeof(AddEditBankAccountWindow),
                                        new PropertyMetadata(Visibility.Visible));

        /// <summary>
        /// Отображение поля для ввода процентной ставки
        /// </summary>
        [Description("Отображение поля для ввода процентной ставки")]
        public Visibility InterestRateVisibility
        {
            get => (Visibility)GetValue(InterestRateVisibilityProperty);
            set => SetValue(InterestRateVisibilityProperty, value);
        }

        #endregion

        #region Отображение поля для ввода процентной ставки

        public static readonly DependencyProperty DepositStatusVisibilityProperty =
            DependencyProperty.Register(nameof(DepositStatusVisibility),
                                        typeof(Visibility),
                                        typeof(AddEditBankAccountWindow),
                                        new PropertyMetadata(Visibility.Visible));

        /// <summary>
        /// Отображение поля выбора статуса депозита
        /// </summary>
        [Description("Отображение поля для ввода процентной ставки")]
        public Visibility DepositStatusVisibility
        {
            get => (Visibility)GetValue(DepositStatusVisibilityProperty);
            set => SetValue(DepositStatusVisibilityProperty, value);
        }

        #endregion

        #region Текст кнопки ввода

        public static readonly DependencyProperty TextOfInputButtonProperty =
            DependencyProperty.Register(nameof(TextOfInputButton),
                                        typeof(string),
                                        typeof(AddEditBankAccountWindow),
                                        new PropertyMetadata("Ok"));

        /// <summary>
        /// Текст кнопки ввода
        /// </summary>
        [Description("Текст кнопки ввода")]
        public string TextOfInputButton
        {
            get => (string)GetValue(TextOfInputButtonProperty);
            set => SetValue(TextOfInputButtonProperty, value);
        }

        #endregion

        public AddEditBankAccountWindow() => InitializeComponent();        
    }
}
