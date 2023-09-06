using Discovery.Weather.DataTransferObjects;
using System.Diagnostics;

namespace DiscoverWeatherApplication;

public partial class WeatherForecastSelectedDayDetails : ContentPage
{
	public WeatherForecastSelectedDayDetails()
	{
		InitializeComponent();
	}

    //Page that opens when list item(day of week) is selected from list.
    public void UpdateForecast(WeatherList weatherForecastData)
    {

        if (weatherForecastData != null)
        {
            BindingContext = weatherForecastData;
        }
        else
        {
            BindingContext = null;
            Debug.WriteLine(BindingContext, "weatherForecastData data empty");
        }
    }
}