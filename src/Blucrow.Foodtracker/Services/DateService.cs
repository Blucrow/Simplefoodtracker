namespace Blucrow.Foodtracker.Services
{
    public static class DateService
    {
        public static DateOnly Today()
        {
            return DateOnly.FromDateTime(DateTime.Now);
        }
    }
}
