using BaseClassesLibrary;
using EnumLibrary;
using System;
using System.Globalization;

namespace ConverterLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class GenderToTextConverter : BaseConverter<GenderToTextConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is Gender index)
            {
                switch (index)
                {
                    case Gender.MAN:
                        return "муж";
                    case Gender.WOMAN:
                        return "жен";
                }
            }

            throw new ArgumentException();
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is string index)
            {
                switch (index)
                {
                    case "муж":
                        return Gender.MAN;
                    case "жен":
                        return Gender.WOMAN;
                }
            }

            throw new ArgumentException();
        }
    }
}
