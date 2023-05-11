namespace ClaimsAreUs.Common.Extensions
{
    /// <summary>
    ///     Helper extensions for dateTime objects
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        ///     Calculate difference in days between referenceDate and comparisonDate
        /// </summary>
        /// <param name="referenceDate"></param>
        /// <param name="comparisonDate"></param>
        /// <returns></returns>
        public static int DaysBetweenDates(this DateTime referenceDate, DateTime comparisonDate)
        {
            return Math.Abs(referenceDate.Subtract(comparisonDate).Days);
        }
    }
}