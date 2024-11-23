static class CHelp
{
    // Somenice helper methods for input:
    public static int ReadInt()
    {
        int input;
        while (!int.TryParse(Console.ReadLine(), out input))
        {
            Console.WriteLine("Ogiltig inmatning, försök igen:");
        }
        return input;
    }

    public static DateTime ReadDate()
    {
        DateTime input;
        while (!DateTime.TryParse(Console.ReadLine(), out input))
        {
            Console.WriteLine("Ogiltigt datumformat, försök igen (åååå-mm-dd):");
        }
        return input;
    }

    public static string ReadString()
    {
        string input;
        while (string.IsNullOrEmpty(input = Console.ReadLine()))
        {
            Console.WriteLine("Ogiltig inmatning, försök igen:");
        }
        return input;
    }
}