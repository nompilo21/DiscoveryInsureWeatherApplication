using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discovery.Weather.BusinessLogic
{
    //description: Converts input temperature input from fahrenheit to celcius
    //returns appropriate picture according to temperature range. 
    public class TemperatureToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double temperatureFahrenheit)
            {
                // Convert Fahrenheit to Celsius
                double temperatureCelsius = (temperatureFahrenheit - 32) * 5 / 9;

                if (temperatureCelsius >= 28)
                {
                    return "hotweather.png";
                }
                if (temperatureCelsius <= 24 && temperatureCelsius >= 20)
                {
                    return "suncloud.png";
                }
                else if (temperatureCelsius <= 16 && temperatureCelsius >= 15)
                {
                    return "windyweather.png";
                }
                else if (temperatureCelsius < 15)
                {
                    return "coldweather.png";
                }
                else
                {
                    return "moderateweather.png";
                }
            }

            return "weather.png";
        }


        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}






