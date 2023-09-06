using System;
using System.Globalization;
using Discovery.Weather.BusinessLogic;
using Xunit;

public class TemperatureToImageConverterTests
{
    [Theory]
    [InlineData(86.0, "hotweather.png")]     // 86°F is hot
    [InlineData(73.4, "suncloud.png")]       // 73.4°F is between 20°C and 24°C
    [InlineData(59.0, "windyweather.png")]   // 59°F is between 15°C and 16°C
    [InlineData(32.0, "coldweather.png")]    // 32°F is cold
    [InlineData(77.0, "moderateweather.png")]// 77°F is between 24°C and 28°C
    [InlineData(23.0, "coldweather.png")]    // 23°F is cold
    public void Convert_Should_Return_Correct_Image_Name(double temperatureFahrenheit, string expectedImageName)
    {
        // Arrange
        var converter = new TemperatureToImageConverter();

        // Act
        var result = converter.Convert(temperatureFahrenheit, typeof(string), null, CultureInfo.InvariantCulture);

        // Assert
        Assert.IsType<string>(result);
        Assert.Equal(expectedImageName, result);
    }

    [Fact]
    public void Convert_Should_Return_Default_Image_Name_For_Non_Double_Input()
    {
        // Arrange
        var converter = new TemperatureToImageConverter();

        // Act
        var result = converter.Convert("Not a double", typeof(string), null, CultureInfo.InvariantCulture);

        // Assert
        Assert.IsType<string>(result);
        Assert.Equal("weather.png", result);
    }
}
