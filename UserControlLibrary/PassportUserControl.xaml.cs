using System.Windows.Controls;
using System.ComponentModel;
using System.Windows;
using System;

namespace UserControlLibrary
{
    public partial class PassportUserControl : UserControl
    {
        #region Название

        public static readonly DependencyProperty TitleUCProperty =
           DependencyProperty.Register(nameof(TitleUC),
                                       typeof(string),
                                       typeof(PassportUserControl),
                                       new PropertyMetadata(default(string)));

        [Description("Название")]
        public string TitleUC
        {
            get => (string)GetValue(TitleUCProperty);
            set => SetValue(TitleUCProperty, value);
        }

        #endregion

        #region Номер паспорта

        public static readonly DependencyProperty NumberUCProperty =
           DependencyProperty.Register(nameof(NumberUC),
                                       typeof(uint?),
                                       typeof(PassportUserControl),
                                       new PropertyMetadata(default(uint?)));

        [Description("Номер паспорта")]
        public uint? NumberUC
        {
            get => (uint?)GetValue(NumberUCProperty);
            set => SetValue(NumberUCProperty, value);
        }

        #endregion

        #region Серия паспорта

        public static readonly DependencyProperty SeriesUCProperty =
           DependencyProperty.Register(nameof(SeriesUC),
                                       typeof(uint?),
                                       typeof(PassportUserControl),
                                       new PropertyMetadata(default(uint?)));

        [Description("Серия паспорта")]
        public uint? SeriesUC
        {
            get => (uint?)GetValue(SeriesUCProperty);
            set => SetValue(SeriesUCProperty, value);
        }

        #endregion

        #region Код подразделения левый

        public static readonly DependencyProperty DivisionCodeLeftUCProperty =
           DependencyProperty.Register(nameof(DivisionCodeLeftUC),
                                       typeof(uint?),
                                       typeof(PassportUserControl),
                                       new PropertyMetadata(default(uint?)));

        [Description("Код подразделения левый")]
        public uint? DivisionCodeLeftUC
        {
            get => (uint?)GetValue(DivisionCodeLeftUCProperty);
            set => SetValue(DivisionCodeLeftUCProperty, value);
        }

        #endregion

        #region Код подразделения правый

        public static readonly DependencyProperty DivisionCodeRightUCProperty =
           DependencyProperty.Register(nameof(DivisionCodeRightUC),
                                       typeof(uint?),
                                       typeof(PassportUserControl),
                                       new PropertyMetadata(default(uint?)));

        [Description("Код подразделения правый")]
        public uint? DivisionCodeRightUC
        {
            get => (uint?)GetValue(DivisionCodeRightUCProperty);
            set => SetValue(DivisionCodeRightUCProperty, value);
        }

        #endregion

        #region Дата выдачи паспорта

        public static readonly DependencyProperty DateOfIssueUCProperty =
           DependencyProperty.Register(nameof(DateOfIssueUC),
                                       typeof(DateTime?),
                                       typeof(PassportUserControl),
                                       new PropertyMetadata(default(DateTime?)));

        [Description("Дата выдачи паспорта")]
        public DateTime? DateOfIssueUC
        {
            get => (DateTime?)GetValue(DateOfIssueUCProperty);
            set => SetValue(DateOfIssueUCProperty, value);
        }

        #endregion

        #region Место выдачи паспорта

        public static readonly DependencyProperty PlaceOfIssueUCProperty =
           DependencyProperty.Register(nameof(PlaceOfIssueUC),
                                       typeof(string),
                                       typeof(PassportUserControl),
                                       new PropertyMetadata(default(string)));

        [Description("Место выдачи паспорта")]
        public string PlaceOfIssueUC
        {
            get => (string)GetValue(PlaceOfIssueUCProperty);
            set => SetValue(PlaceOfIssueUCProperty, value);
        }

        #endregion

        public PassportUserControl() => InitializeComponent();             
    }
}
