using System;
using System.Globalization;

namespace Discovery.Weather.BusinessLogic
{
    // Description: Takes in datetime as a Unix timestamp and converts it to a string value date in GMT+2 (Central Africa Time - CAT).
    public class LongToDateTimeConverter : IValueConverter
    {
        private DateTime _time = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        private TimeSpan _gmtPlus2Offset = TimeSpan.FromHours(2); // GMT+2 offset

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is long unixTimestamp)
            {
                DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(unixTimestamp).ToOffset(_gmtPlus2Offset);
                return dateTimeOffset.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) + " GMT+2";
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
