using System;
using System.Globalization;
using Discovery.Weather.BusinessLogic;
using Xunit;

public class DateToStringConverterTests
{
    [Fact]
    public void Convert_Should_Return_DayOfWeek_When_Given_UnixTimestamp()
    {
        DateTime mondayDateTime = new DateTime(2023, 9, 5); // A Monday
        long unixTimestamp = ((DateTimeOffset)mondayDateTime).ToUnixTimeSeconds();

        // Create an instance of the DateToStringConverter
        var converter = new DateToStringConverter();

        var result = converter.Convert(unixTimestamp, typeof(string), null, CultureInfo.InvariantCulture);

        Assert.IsType<string>(result);
        Assert.Equal("Monday", result);
    }

    [Fact]
    public void Convert_Should_Return_Empty_String_When_Given_Non_UnixTimestamp()
    {

        object nonUnixTimestamp = "Not a UnixTimestamp";

        // Create an instance of the DateToStringConverter
        var converter = new DateToStringConverter();

        var result = converter.Convert(nonUnixTimestamp, typeof(string), null, CultureInfo.InvariantCulture);

        Assert.IsType<string>(result);
        Assert.Equal(string.Empty, result);
    }
}
