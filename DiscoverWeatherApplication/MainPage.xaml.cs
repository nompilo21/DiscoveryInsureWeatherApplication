using Discovery.Weather.DataTransferObjects;

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
            string weatherRequestUrl = GenerateForecastRequestURL(WeatherDataApiConstants.OpenWeatherMapEndpoint);
            string weatherForecastRequestUrl = GenerateForecastRequestURL(WeatherDataApiConstants.WeatherForecastEndpoint);

            WeatherData weatherData = await _weatherService.GetWeatherData(weatherRequestUrl);
            WeatherForecastData weatherForecastData = await _weatherService.GetWeatherForecastData(weatherForecastRequestUrl);

            if (weatherData != null && weatherForecastData != null)
            {
                BindingContext = weatherData;
                BindingContext = weatherForecastData;

            }
            else
            {
                // Handle the case where weather data is not available or the request fails
                // You can display an error message or take appropriate action here.
                Console.WriteLine("Error");
            }

        }

        async void OnGetWeatherButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_cityEntry.Text))
            {
                string weatherRequestUrl = GenerateRequestURL(WeatherDataApiConstants.OpenWeatherMapEndpoint);
                string weatherForecastRequestUrl = GenerateRequestURL(WeatherDataApiConstants.WeatherForecastEndpoint);


                WeatherData weatherData = await _weatherService.GetWeatherData(weatherRequestUrl);
                WeatherForecastData weatherForecastData = await _weatherService.GetWeatherForecastData(weatherForecastRequestUrl);

                if (weatherData != null && weatherForecastData != null)
                {
                    BindingContext = weatherData;
                    BindingContext = weatherForecastData;

                }
                else
                {
                    // Handle the case where weather data is not available or the request fails
                    // You can display an error message or take appropriate action here.
                    Console.WriteLine("Error");
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


        string GenerateRequestURL(string endPoint)
        {
            string requestUri = endPoint;
            requestUri += $"?q={_cityEntry.Text}";
            requestUri += "&units=imperial";
            requestUri += $"&APPID={WeatherDataApiConstants.WeatherMapAPIKey}";
            return requestUri;
        }
    }
}
