using BaseClassesLibrary;
using EnumLibrary;
using System;
using System.Globalization;

namespace ConverterLibrary
{
    public class DepositStatusToTextConverter : BaseConverter<DepositStatusToTextConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DepositStatus index)
            {
                switch (index)
                {
                    case DepositStatus.WITHOUTCAPITALIZATION:
                        return "Без капитализации";
                    case DepositStatus.WITHCAPITALIZATION:
                        return "С капитализацией";
                    default:
                        throw new ArgumentException();
                }
            }

            throw new ArgumentException();
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string index)
            {
                switch (index)
                {
                    case "Без капитализации":
                        return DepositStatus.WITHOUTCAPITALIZATION;
                    case "С капитализацией":
                        return DepositStatus.WITHCAPITALIZATION;
                    default:
                        throw new ArgumentException();
                }
            }

            throw new ArgumentException();
        }
    }
}
