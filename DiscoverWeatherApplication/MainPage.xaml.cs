using Discovery.Weather.BusinessLogic;
using Discovery.Weather.DataTransferObjects;
using Microsoft.Maui.Controls;
using System.Globalization;
using System.Runtime.Intrinsics.X86;
using System.Threading.Channels;

namespace DiscoverWeatherApplication
{
    public partial class MainPage : ContentPage
    {
        WeatherService _weatherService;

        public MainPage()
        {
            InitializeComponent();
            _weatherService = new WeatherService(); // Create an instance of WeatherService
        }

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
            }

        }

        private async void OnListItemClicked(object sender, EventArgs e)
        {
            if (e is SelectedItemChangedEventArgs tappedEventArgs)
            {
                WeatherList selectedItem = (WeatherList)tappedEventArgs.SelectedItem; // Use Item to get the selected item

                if (selectedItem != null)
                {
                    var bottomSheet = new WeatherBottomSheet();
                    bottomSheet.UpdateForecast(selectedItem);
                    await Navigation.PushAsync(bottomSheet);
                }
                else
                {
                    // Handle the case where selectedItem is null (no item selected)
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
