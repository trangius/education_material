class Program
{
    static void Main(string[] args)
    {
        // Gör så att vi kan skicka in en sträng som parameter
        Action<string> myAction = delegate(string msg)
        {
            Console.WriteLine(msg);
        };

        // Anropa delegaten
        myAction("Hello World!");
    }
}