using System;

namespace DebugExample
{
    public class Person
    {
        public string name;
        public int personalNr;

        public Person(string name, int personalNr)
        {
            this.name = name;
            this.personalNr = personalNr;
        }
    }
    // There is something wrong with this code.
    // 1) Just run this code and see what happens. Do NOT google or chatgpt how binary search
    //      is supposed to work. That will spoil this exercise.
    // 2) Try to search with different personal numbers - do some seem to work?
    // 3) Try different numbers while using the debugger, and step trough the search algorithm step
    //      --> what happens?
    // 4) What conclutions can you draw from this?
    // 5) Ok. Now that you've found the error. Can you find a way to solve it? Now you can use google...

    public class BinarySearch
    {
        public static void TestBS()
        {
            List<Person> people = new List<Person>
            {
                new Person("Anna Andersson", 50125),
                new Person("Bertil Bengtsson", 50232),
                new Person("Carl Carlsson", 50315),
                new Person("David Davidsson", 50375)
            };

            // Sort the list before searchning. Necessary for binary search.
            people.Sort((a, b) => a.personalNr.CompareTo(b.personalNr));

            
            int personalNrToFind = 50375;
            int index = DoBinarySearch(people, personalNrToFind);

            if(index != -1)
            {
                Console.WriteLine($"Personen {people[index].name} med personnummer {personalNrToFind} hittades på index {index}.");
            }
            else
            {
                Console.WriteLine($"Personen med personnummer {personalNrToFind} hittades inte.");
            }
        }


        private static int DoBinarySearch(List<Person> persons, int personalNr)
        {
            // bra ställe att sätta break point?
            int min = 0;
            int max = persons.Count - 1;

            while (min <= max)
            {
                int middle = (min + max) / 2;
                if (persons[middle].personalNr == personalNr)
                {
                    return middle;
                }
                else if (persons[middle].personalNr < personalNr)
                {
                    min = middle;
                }
                else
                {
                    max = middle;
                }
            }

            return -1; // Inte funnet
        }
    }
}
