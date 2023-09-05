using System;
using System.Globalization;

namespace Discovery.Weather.BusinessLogic
{
    public class FahrenheitToCelsiusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double fahrenheit)
            {
                // Convert Fahrenheit to Celsius
                double celsius = (fahrenheit - 32) * 5 / 9;

                // Round the result to two decimal places
                return Math.Round(celsius, 1);
            }

            // If the input is not a valid double, return null
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
