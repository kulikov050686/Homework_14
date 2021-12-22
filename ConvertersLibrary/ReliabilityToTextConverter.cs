using BaseClassesLibrary;
using EnumLibrary;
using System;
using System.Globalization;

namespace ConverterLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class ReliabilityToTextConverter : BaseConverter<ReliabilityToTextConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is Reliability index)
            {
                switch (index)
                {
                    case Reliability.FIRST:
                        return "Низкая";
                    case Reliability.SECOND:
                        return "Средняя";
                    case Reliability.THIRD:
                        return "Высокая";
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
                    case "Низкая":
                        return Reliability.FIRST;
                    case "Средняя":
                        return Reliability.SECOND;
                    case "Высокая":
                        return Reliability.THIRD;
                }
            }

            throw new ArgumentException();
        }
    }
}
