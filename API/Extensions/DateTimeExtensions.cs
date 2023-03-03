namespace API.Extensions
{
    public static class DateTimeExtensions
    {
        public static int CalculateAge(this DateOnly dob)
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow);

            var yearDifference = today.Year - dob.Year;

            var monthDifference = today.Month - dob.Month;

            var dayDifference = today.Day - dob.Day;

            Console.WriteLine("Year Different : " + yearDifference);

            Console.WriteLine("Month Different : " + monthDifference);

            Console.WriteLine("Day Different : " + dayDifference);


            if (monthDifference < 0)
            {
                yearDifference--;
            }
            else
            {
                if (dayDifference < 0)
                {
                    yearDifference--;
                }
            }

            return yearDifference;
        }
    }
}