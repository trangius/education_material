// Innehåll i Utilities.cs
namespace MyUtilities
{
    public class MathHelper
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }
    }
}

// Innehåll i Program.cs
using MyUtilities;  // Lägg till detta för att använda MathHelper-klassen

namespace MyProgram
{
    class Program
    {
        static void Main()
        {
            int sum = MathHelper.Add(5, 7);
            System.Console.WriteLine($"Summan är: {sum}");
        }
    }
}
