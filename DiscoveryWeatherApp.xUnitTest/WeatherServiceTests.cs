using System.Net.Http;
using System.Threading.Tasks;
using DiscoverWeatherApplication;
using Discovery.Weather.DataTransferObjects;
using Newtonsoft.Json;
using RichardSzalay.MockHttp;
using Xunit;

public class WeatherServiceTests
{
    [Fact]
    public async Task GetWeatherData_Should_Return_WeatherData()
    {

        var expectedWeatherData = new WeatherData { /* Initialize with your expected data */ };
        var jsonContent = JsonConvert.SerializeObject(expectedWeatherData);

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("https://api.weather.com/*")
            .Respond("application/json", jsonContent);

        var httpClient = new HttpClient(mockHttp);
        var weatherService = new WeatherService();

        // Use the SetHttpClient method to inject the mock HttpClient
        weatherService.SetHttpClient(httpClient);

        var result = await weatherService.GetWeatherData("https://api.weather.com/yourEndpoint");

        Assert.NotNull(result);
    }

}
