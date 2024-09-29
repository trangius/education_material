namespace DebugExample
{
    public class Program
    {
        public static void Main()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("[B]inary search");
                Console.WriteLine("[W]eekdays");
                Console.WriteLine("[S]tack overflow");
                Console.WriteLine("[D]ivision calculator");
                Console.WriteLine("[Q]uit");
                Console.Write("Val: ");
                string choice = Console.ReadLine();

                switch (choice.ToLower())
                {
                    case "b":
                        BinarySearch.TestBS();
                        break;
                    case "w":
                        Weekdays.TodayAndTomorrow();
                        break;
                    case "s":
                        Console.Write("Enter a value: ");
                        if(!int.TryParse(Console.ReadLine(), out int x))
                        {
                            Console.WriteLine("only integers please, setting x to 0");
                            x = 0;
                        }
                        StackOverFlow.AStupidMethod(x);
                        break;
                    case "d":
                        Division.Calculator();
                        break;
                    case "q":
                        Console.WriteLine("Thank you, good bye...");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("I don't understand...");
                        break;
                }
            }
        }
    }
}
