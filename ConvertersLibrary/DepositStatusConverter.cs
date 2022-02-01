using BaseClassesLibrary;
using EnumLibrary;
using System;
using System.Globalization;

namespace ConverterLibrary
{
    public class DepositStatusConverter : BaseConverter<DepositStatusConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is DepositStatus index)
            {
                switch (index)
                {
                    case DepositStatus.WITHOUTCAPITALIZATION:
                        return 0;
                    case DepositStatus.WITHCAPITALIZATION:
                        return 1;
                    default:
                        throw new ArgumentException();
                }
            }

            throw new ArgumentException();
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is int index)
            {
                switch (index)
                {
                    case 0:
                        return DepositStatus.WITHOUTCAPITALIZATION;
                    case 1:
                        return DepositStatus.WITHCAPITALIZATION;
                    default:
                        throw new ArgumentException();
                }
            }

            throw new ArgumentException();
        }
    }
}
