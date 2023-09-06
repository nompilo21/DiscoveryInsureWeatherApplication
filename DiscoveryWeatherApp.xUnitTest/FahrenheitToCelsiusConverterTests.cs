using System;
using System.Globalization;
using Discovery.Weather.BusinessLogic;
using Xunit;

public class FahrenheitToCelsiusConverterTests
{
    [Fact]
    public void Convert_Should_Convert_Fahrenheit_To_Celsius()
    {
        // Arrange
        double fahrenheit = 68; // 68°F is 20°C

        // Create an instance of the FahrenheitToCelsiusConverter
        var converter = new FahrenheitToCelsiusConverter();

        // Act
        var result = converter.Convert(fahrenheit, typeof(double), null, CultureInfo.InvariantCulture);

        // Assert
        Assert.IsType<double>(result);
        Assert.Equal(20.0, (double)result, 1); // Allow a small margin of error for rounding
    }

    [Fact]
    public void Convert_Should_Return_Null_When_Given_Non_Double_Input()
    {
        // Arrange
        object nonDoubleInput = "Not a double value";

        // Create an instance of the FahrenheitToCelsiusConverter
        var converter = new FahrenheitToCelsiusConverter();

        // Act
        var result = converter.Convert(nonDoubleInput, typeof(double), null, CultureInfo.InvariantCulture);

        // Assert
        Assert.Null(result);
    }
}
