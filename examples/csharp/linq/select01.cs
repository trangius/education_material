using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    public static void Main()
    {
        // En lista med personer
        var people = new List<Person>
        {
            new Person { FirstName = "Anna", LastName = "Andersson", BirthYear = 1990 },
            new Person { FirstName = "Lars", LastName = "Larsson", BirthYear = 1985 },
            new Person { FirstName = "Sara", LastName = "Svensson", BirthYear = 2000 }
        };

        // Projektera till en lista med fullständiga namn och ålder
        var projectedPeople = people.Select(person => new
        {
            FullName = $"{person.FirstName} {person.LastName}",
            Age = DateTime.Now.Year - person.BirthYear
        });

        // Skriv ut resultaten
        foreach (var person in projectedPeople)
        {
            Console.WriteLine($"Name: {person.FullName}, Age: {person.Age}");
        }
    }
}

class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int BirthYear { get; set; }
}
