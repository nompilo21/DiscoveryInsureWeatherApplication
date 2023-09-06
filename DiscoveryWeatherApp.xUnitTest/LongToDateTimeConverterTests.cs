using System;
using System.Globalization;
using Discovery.Weather.BusinessLogic;
using Xunit;

public class LongToDateTimeConverterTests
{
    [Fact]
    public void Convert_Should_Convert_Long_To_DateTime_In_CAT_Timezone()
    {
        long unixTimestamp = 1630863600; // Unix timestamp representing a date and time

        // Create an instance of the LongToDateTimeConverter
        var converter = new LongToDateTimeConverter();

        var result = converter.Convert(unixTimestamp, typeof(string), null, CultureInfo.InvariantCulture);

        // Convert the result to a DateTime object in CAT timezone (GMT+2)
        var catTimeZone = TimeZoneInfo.FindSystemTimeZoneById("South Africa Standard Time"); // CAT timezone
        var catDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTimeOffset.FromUnixTimeSeconds(unixTimestamp).UtcDateTime, catTimeZone);

        // Format the CAT DateTime as a string with the specified format
        var expectedCatDateTimeString = catDateTime.ToString("yyyy-MM-dd HH:mm:ss 'GMT+2'", CultureInfo.InvariantCulture);

        Assert.IsType<string>(result);
        Assert.Equal(expectedCatDateTimeString, result);
    }

    [Fact]
    public void Convert_Should_Return_Null_When_Given_Non_Long_Input()
    {
        object nonLongInput = "Not a long value";

        // Create an instance of the LongToDateTimeConverter
        var converter = new LongToDateTimeConverter();

        var result = converter.Convert(nonLongInput, typeof(long), null, CultureInfo.InvariantCulture);

        Assert.Null(result);
    }
}
