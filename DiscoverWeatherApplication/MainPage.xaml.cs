using Discovery.Weather.BusinessLogic;
using Discovery.Weather.DataTransferObjects;
using Microsoft.Maui.Controls;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Intrinsics.X86;
using System.Threading.Channels;

namespace DiscoverWeatherApplication
{
    //description: This is the Apps main page along with
    //all requests and method calls for binding data to the view model
    // A new instance of WeatherService is created to access request data.
    public partial class MainPage : ContentPage
    {
        WeatherService _weatherService;

        public MainPage()
        {
            InitializeComponent();
            _weatherService = new WeatherService(); 
        }

        //Loads/opens view item when application initially loads.
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            LongToDateTimeConverter longToDateTimeConverter = new LongToDateTimeConverter();
            string weatherRequestUrl = GenerateForecastRequestURL(WeatherDataApiConstants.OpenWeatherMapEndpoint);
            string weatherForecastRequestUrl = GenerateForecastRequestURL(WeatherDataApiConstants.WeatherForecastEndpoint);

            WeatherData weatherData = await _weatherService.GetWeatherData(weatherRequestUrl);
            weatherData.forecastData = await _weatherService.GetWeatherForecastData(weatherForecastRequestUrl);
            weatherData.forecastData.List = weatherData.forecastData.List
              .GroupBy(data =>
              {
                  if (DateTime.TryParseExact(data.DtTxt, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime))
                  {
                      return dateTime.Date;
                  }
                  else
                  {
                      // Handle invalid datetime strings
                      return DateTime.MinValue.Date;
                  }
              })
              .Select(group => group.First())
              .Take(7)
              .ToList();

            if (weatherData != null)
            {
                BindingContext = weatherData;
            }
            else
            {
                // Handle the case where weather data is not available or the request fails
                BindingContext = null;
                Debug.WriteLine(BindingContext, "weatherForecastData data empty");
            }

        }

        //List item event listener for list item selected.
        //WeatherForecastSelectedDayDetails is opened when each item is selected.
        private async void OnListItemClicked(object sender, EventArgs e)
        {
            if (e is SelectedItemChangedEventArgs tappedEventArgs)
            {
                WeatherList selectedItem = (WeatherList)tappedEventArgs.SelectedItem; // Use Item to get the selected item

                if (selectedItem != null)
                {
                    var weatherForecastSelected = new WeatherForecastSelectedDayDetails();
                    weatherForecastSelected.UpdateForecast(selectedItem);
                    await Navigation.PushAsync(weatherForecastSelected);
                }
                else
                {
                    // Handle the case where selectedItem is null (no item selected)
                    Debug.WriteLine("Failed to select item from List");
                }
            }
        }


        string GenerateForecastRequestURL(string endPoint)
        {
            string name = "Durban";
            string requestUri = endPoint;
            requestUri += $"?q={name}";
            requestUri += "&units=imperial";
            requestUri += $"&APPID={WeatherDataApiConstants.WeatherMapAPIKey}";
            return requestUri;
        }
    }
}
