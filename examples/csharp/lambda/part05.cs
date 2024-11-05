// Fler lambda exempel
class Program
{
    static void Main(string[] args)
    {
        // ingen parameter, inget returvärde:
        Action justPrint = () => Console.WriteLine("Just Print!");

        // en parameter, inget returvärde:
        Action<string> printString = s => Console.WriteLine(s);

        // två parametrar, inget returvärde:
        Action<string, int> printTimes = (s, n) =>
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{i}: {s}");
            }
        };

        justPrint();
        printString("printstring");
        printTimes("printTimes!", 3);

        // en parameter, ett returvärde:
        Func<string, string> addExclamation = s =>
        {
            return s + "!";
        };

        Func<string, string> addExclamationAgain = s => s + "!";

        Console.WriteLine(addExclamation("addExclamation"));
        Console.WriteLine(addExclamationAgain("addExclamationAgain")); 
    }
}
