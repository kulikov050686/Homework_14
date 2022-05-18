using BaseClassesLibrary;
using EnumLibrary;
using System;
using System.Globalization;

namespace ConverterLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class IntToReliabilityConverter : BaseConverter<IntToReliabilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is Reliability index)
            {
                switch (index)
                {
                    case Reliability.FIRST:
                        return 0;
                    case Reliability.SECOND:
                        return 1;
                    case Reliability.THIRD:
                        return 2;
                }
            }

            throw new ArgumentException();
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int index)
            {
                switch (index)
                {
                    case 0:
                        return Reliability.FIRST;
                    case 1:
                        return Reliability.SECOND;
                    case 2:
                        return Reliability.THIRD;
                }
            }

            throw new ArgumentException();
        }
    }
}
