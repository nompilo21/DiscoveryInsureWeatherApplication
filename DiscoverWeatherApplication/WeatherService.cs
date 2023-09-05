using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Discovery.Weather.DataTransferObjects;
using Newtonsoft.Json;

namespace DiscoverWeatherApplication
{
    public class WeatherService
    {
        // HTTP client for making requests to the weather API
        HttpClient _client; 

        public WeatherService()
        {
            // Initialize the HTTP client
            _client = new HttpClient(); 
        }

        // Method for retrieving weather data asynchronously
        public async Task<WeatherData> GetWeatherData(string query)
        {
            // Initialize the variable to store weather data
            WeatherData weatherData = null; 

            try
            {
                // Send an HTTP GET request.
                var response = await _client.GetAsync(query);

                // Check if the HTTP response indicates success (status code 200)
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    var content = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response into a WeatherData object
                    weatherData = JsonConvert.DeserializeObject<WeatherData>(content);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions that may occur during the request or deserialization
                Debug.WriteLine(ex.Message);
                throw; // Rethrow the exception to be handled at a higher level
            }

            // Return the retrieved weather data or null if there was an error
            return weatherData;
        }


        // Method for retrieving weather forecast data asynchronously
        public async Task<WeatherForecastData> GetWeatherForecastData(string query)
        {
            // Initialize the variable to store weather forecast data
            WeatherForecastData weatherForecastData = null;

            try
            {
                // Send an HTTP GET request.
                var response = await _client.GetAsync(query);

                // Check if the HTTP response indicates success (status code 200)
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    var content = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response into a WeatherData object
                    weatherForecastData = JsonConvert.DeserializeObject<WeatherForecastData>(content);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions that may occur during the request or deserialization
                Debug.WriteLine(ex.Message);
                throw; // Rethrow the exception to be handled at a higher level
            }

            // Return the retrieved weather data or null if there was an error
            return weatherForecastData;
        }
    }
}
