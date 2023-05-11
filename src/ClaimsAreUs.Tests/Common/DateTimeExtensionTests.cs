using ClaimsAreUs.Common.Extensions;
using FluentAssertions;

namespace ClaimsAreUs.Tests.Common
{
    public class DateTimeExtensionTests
    {
        [Theory]
        [InlineData("2020-01-01T00:00:00", "2020-01-02T00:00:00", 1)] // One year
        [InlineData("2020-01-01T00:00:00", "2019-12-31T00:00:00", 1)] // Backwards but positive number
        [InlineData("2020-01-01T12:00:00", "2019-12-31T00:00:00", 1)] // Day and a half
        [InlineData("2020-01-01T12:00:00", "2019-12-30T00:00:00", 2)] // Two and a half days
        [InlineData("2020-01-01T00:00:00", "2021-01-01T00:00:00", 366)] // Leap year
        [InlineData("2019-01-01T00:00:00", "2020-01-01T00:00:00", 365)] // Normal year
        public void Given_Two_Dates_Calculates_Difference_In_Days(string referenceDateStr, string comparisonDateStr,
            int expectedDifference)
        {
            var referenceDate = DateTime.Parse(referenceDateStr);
            var comparisonDate = DateTime.Parse(comparisonDateStr);

            referenceDate
                .DaysBetweenDates(comparisonDate)
                .Should()
                .Be(expectedDifference);
        }
    }
}