class Program
{
    static void Main(string[] args)
    {
        // Skapa en delegat av type Action,
        // myAction som pekar på en anonym metod
        Action myAction = delegate()
        {
            Console.WriteLine("Hello World!");
        };

        // Anropa delegaten
        myAction();
    }
}
