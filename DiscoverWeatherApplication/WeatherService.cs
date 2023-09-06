using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Discovery.Weather.DataTransferObjects;
using Newtonsoft.Json;

namespace DiscoverWeatherApplication
{
    //This is the weather service where the  HTTP client for making requests to the weather API.
    public class WeatherService
    {
        protected HttpClient _client;

        public WeatherService()
        {
            _client = new HttpClient(); 
        }

        // Method for retrieving weather data asynchronously
        public async Task<WeatherData> GetWeatherData(string query)
        {

            WeatherData weatherData = null; 

            try
            {
                // Send an HTTP GET request.
                var response = await _client.GetAsync(query);

                // Check if the HTTP response indicates success (status code 200)
                if (response.IsSuccessStatusCode)
                {
          
                    var content = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response into a WeatherData object
                    weatherData = JsonConvert.DeserializeObject<WeatherData>(content);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions that may occur during the request or deserialization
                Debug.WriteLine(ex.Message);
                throw; 
            }

            return weatherData;
        }


        // Method for retrieving weather forecast data asynchronously
        public async Task<WeatherForecastData> GetWeatherForecastData(string query)
        {
          
            WeatherForecastData weatherForecastData = null;

            try
            {
                // Send an HTTP GET request.
                var response = await _client.GetAsync(query);

                // Check if the HTTP response indicates success (status code 200)
                if (response.IsSuccessStatusCode)
                {
                   
                    var content = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response into a WeatherData object
                    weatherForecastData = JsonConvert.DeserializeObject<WeatherForecastData>(content);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions that may occur during the request or deserialization
                Debug.WriteLine(ex.Message);
                throw;
            }

            return weatherForecastData;
        }

        public void SetHttpClient(HttpClient httpClient)
        {
            _client = httpClient;
        }
    }


}
