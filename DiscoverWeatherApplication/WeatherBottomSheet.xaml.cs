using Discovery.Weather.DataTransferObjects;

namespace DiscoverWeatherApplication;

public partial class WeatherBottomSheet : ContentPage
{
	public WeatherBottomSheet()
	{
		InitializeComponent();
	}


    public void UpdateForecast(WeatherList weatherForecastData)
    {

        // Update your UI elements with the forecast data
        // For example, set the Text of labels or populate a ListView
        if (weatherForecastData != null)
        {
            BindingContext = weatherForecastData;
        }
        else
        {
            // Handle the case where weather data is not available or the request fails
        }
    }
}