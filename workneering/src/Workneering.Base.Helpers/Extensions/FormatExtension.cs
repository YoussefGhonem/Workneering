namespace Workneering.Base.Helpers.Extensions
{
    public static class FormatExtension
    {
        public static string FormatDateTimeOffset(this DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset.ToString("dd MMM yyyy");
        }

        static void Main(string[] args)
        {
            DateTimeOffset dateToFormat = new DateTimeOffset(new DateTime(2023, 11, 12), TimeSpan.Zero); // Example DateTimeOffset
            string formattedDate = FormatDateTimeOffset(dateToFormat);
            Console.WriteLine(formattedDate);
        }
    }
}
