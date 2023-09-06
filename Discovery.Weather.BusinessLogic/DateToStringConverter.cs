using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discovery.Weather.BusinessLogic
{
    public class DateToStringConverter : IValueConverter
    {

        //description: Takes in date as unix timestamp and returns day in words.
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is long UnixTimestamp)
            {
                DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(UnixTimestamp);
                return dateTimeOffset.ToString("dddd", CultureInfo.InvariantCulture);
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
