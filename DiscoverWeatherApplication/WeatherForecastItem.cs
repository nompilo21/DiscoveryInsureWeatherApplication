using Discovery.Weather.DataTransferObjects;

namespace DiscoverWeatherApplication
{
    internal class WeatherForecastItem
    {
        public long Dt { get; set; }
        public Main Main { get; set; }
        public List<Weather> Weather { get; set; }
    }
}