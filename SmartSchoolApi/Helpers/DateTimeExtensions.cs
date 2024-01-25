namespace SmartSchoolApi.Helpers
{
    public static class DateTimeExtensions
    {
        public static int GetAge(this DateTime dateTime)
        {
            var currentDate = DateTime.UtcNow;
            return currentDate.Year - dateTime.Year;
        }
    }
}
