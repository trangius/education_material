// Används för att kommunicera med användaren via konsolen.
// Just nu finns bara kod för en person, men man kan såklart fylla på med alla
// möjliga objekt.
static class ConsoleUI
{
    public static void PrintPerson(Person person)
    {
        Console.WriteLine("Info about the person.");
        Console.WriteLine("Name:" + person.Name);
        Console.WriteLine("Personal nr:" + person.PersonalNr);
        Console.WriteLine("Address:" + person.Address);
    }
}