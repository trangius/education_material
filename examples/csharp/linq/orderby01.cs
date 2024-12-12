using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public static void Main()
    {
        // En lista med personer
        var people = new List<Person>
        {
            new Person { FirstName = "Sara", LastName = "Svensson", BirthYear = 2000 },
            new Person { FirstName = "Lars", LastName = "Larsson", BirthYear = 1985 },
            new Person { FirstName = "Anna", LastName = "Andersson", BirthYear = 1990 }
        };

        Console.WriteLine("Innan sortering");        
        foreach (var person in people)
        {
            Console.WriteLine($"Name: {person.FirstName} {person.LastName}, BirthYear: {person.BirthYear}");
        }

        // Sortera listan baserat på LastName
        var sortedPeople = people.OrderBy(person => person.LastName);

        Console.WriteLine("-----------------------");
        Console.WriteLine("Efter sortering");
        foreach (var person in sortedPeople)
        {
            Console.WriteLine($"Name: {person.FirstName} {person.LastName}, BirthYear: {person.BirthYear}");
        }
    }
}

class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int BirthYear { get; set; }
}
