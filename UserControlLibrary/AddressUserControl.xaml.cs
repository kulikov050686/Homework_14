using System.Windows.Controls;
using System.ComponentModel;
using System.Windows;
using System;

namespace UserControlLibrary
{
    public partial class AddressUserControl : UserControl
    {
        #region Название

        public static readonly DependencyProperty TitleUCProperty =
           DependencyProperty.Register(nameof(TitleUC),
                                       typeof(string),
                                       typeof(AddressUserControl),
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

        #region Регион или Область

        public static readonly DependencyProperty RegionUCProperty =
            DependencyProperty.Register(nameof(RegionUC),
                                        typeof(string),
                                        typeof(AddressUserControl),
                                        new PropertyMetadata(default(string)));

        /// <summary>
        /// Регион
        /// </summary>
        [Description("Регион")]
        public string RegionUC
        {
            get => (string)GetValue(RegionUCProperty);
            set => SetValue(RegionUCProperty, value);
        }

        #endregion

        #region Город

        public static readonly DependencyProperty CityUCProperty =
            DependencyProperty.Register(nameof(CityUC),
                                        typeof(string),
                                        typeof(AddressUserControl),
                                        new PropertyMetadata(default(string)));

        /// <summary>
        /// Город
        /// </summary>
        [Description("Город")]
        public string CityUC
        {
            get => (string)GetValue(CityUCProperty);
            set => SetValue(CityUCProperty, value);
        }

        #endregion

        #region Район города

        public static readonly DependencyProperty DistrictUCProperty =
            DependencyProperty.Register(nameof(DistrictUC),
                                        typeof(string),
                                        typeof(AddressUserControl),
                                        new PropertyMetadata(default(string)));

        /// <summary>
        /// Район города
        /// </summary>
        [Description("Район города")]
        public string DistrictUC
        {
            get => (string)GetValue(DistrictUCProperty);
            set => SetValue(DistrictUCProperty, value);
        }

        #endregion

        #region Улица

        public static readonly DependencyProperty StreetUCProperty =
            DependencyProperty.Register(nameof(StreetUC),
                                        typeof(string),
                                        typeof(AddressUserControl),
                                        new PropertyMetadata(default(string)));

        /// <summary>
        /// Название улицы
        /// </summary>
        [Description("Название улицы")]
        public string StreetUC
        {
            get => (string)GetValue(StreetUCProperty);
            set => SetValue(StreetUCProperty, value);
        }

        #endregion

        #region Номер дома

        public static readonly DependencyProperty HouseNumberUCProperty =
            DependencyProperty.Register(nameof(HouseNumberUC),
                                        typeof(uint?),
                                        typeof(AddressUserControl),
                                        new PropertyMetadata(default(uint?)));

        /// <summary>
        /// Номер дома
        /// </summary>
        [Description("Номер дома")]
        public uint? HouseNumberUC
        {
            get => (uint?)GetValue(HouseNumberUCProperty);
            set => SetValue(HouseNumberUCProperty, value);
        }

        #endregion

        #region Корпус дома

        public static readonly DependencyProperty HousingUCProperty =
            DependencyProperty.Register(nameof(HousingUC),
                                        typeof(string),
                                        typeof(AddressUserControl),
                                        new PropertyMetadata(default(string)));

        /// <summary>
        /// Корпус дома
        /// </summary>
        [Description("Корпус дома")]
        public string HousingUC
        {
            get => (string)GetValue(HousingUCProperty);
            set => SetValue(HousingUCProperty, value);
        }

        #endregion

        #region Номер квартиры

        public static readonly DependencyProperty ApartmentNumberUCProperty =
            DependencyProperty.Register(nameof(ApartmentNumberUC),
                                        typeof(uint?),
                                        typeof(AddressUserControl),
                                        new PropertyMetadata(default(uint?)));

        /// <summary>
        /// Номер квартиры
        /// </summary>
        [Description("Номер квартиры")]
        public uint? ApartmentNumberUC
        {
            get => (uint?)GetValue(ApartmentNumberUCProperty);
            set => SetValue(ApartmentNumberUCProperty, value);
        }

        #endregion

        #region Дата регистрации

        public static readonly DependencyProperty RegistrationDateUCProperty =
            DependencyProperty.Register(nameof(RegistrationDateUC),
                                        typeof(DateTime?),
                                        typeof(AddressUserControl),
                                        new PropertyMetadata(default(DateTime?)));

        /// <summary>
        /// Дата регистрации
        /// </summary>
        [Description("Дата регистрации")]
        public DateTime? RegistrationDateUC
        {
            get => (DateTime?)GetValue(RegistrationDateUCProperty);
            set => SetValue(RegistrationDateUCProperty, value);
        }

        #endregion

        public AddressUserControl() => InitializeComponent();        
    }
}
