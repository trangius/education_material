namespace DebugExample
{
    public class Weekdays
    {
        // During a certain day this code will crasch.
        // 1) How are you to find out what day?
        // 2) On what line does the problem occur?
        // 3) What is the problem? Read the error message and check with the debugger.
        // 4) How will you fix it? Note: leave the line with the crash as it is and do the fix above it
        public static void TodayAndTomorrow()
        {
            string[] weekdays = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            // We use DateTime to get the day of the week index (0 basead).
            int todayIndex = (int)DateTime.Now.DayOfWeek;
            System.Console.WriteLine("Today index: " + (int)todayIndex);

            // Try to calculate tomorrow's index.
            int tomorrowIndex = (todayIndex + 1);

            Console.WriteLine("Today is: " + weekdays[todayIndex]);
            Console.WriteLine("Tomorrow will be: " + weekdays[tomorrowIndex]);
            Program.Main();
        }
    }
}
