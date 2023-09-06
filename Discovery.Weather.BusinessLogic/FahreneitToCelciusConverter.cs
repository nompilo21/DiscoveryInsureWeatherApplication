using System;
using System.Globalization;

namespace Discovery.Weather.BusinessLogic
{
    public class FahrenheitToCelsiusConverter : IValueConverter
    {
        //description: Takes in temperature in Fahrenheit and converts to degrees celcius round to 1 decimal place
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double fahrenheit)
            {
                
                double celsius = (fahrenheit - 32) * 5 / 9;

                return Math.Round(celsius, 1);
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
