using System.Text.Json; 

// ska bli ett system för ett antikvariat att hålla reda på alla sina böcker
/*
TODO:
* mer single responsibility
* ändra på en bok
* söka bok
* utskrift med villkor
*/
static class Program
{
    static List<Book> allBooks = new List<Book>();
    static void Main()
    {
        string jsonString = File.ReadAllText("allbooks.json");
        allBooks = JsonSerializer.Deserialize<List<Book>>(jsonString);

        Console.WriteLine("Välkommen till antikvariatet!");
        bool isRunning = true;
        
        // Mainloop som hanterar menyn   
        while(isRunning)
        {
            Console.WriteLine("Vad vill du göra?");
            Console.WriteLine("1. Lägg till en bok");
            Console.WriteLine("2. Lista alla böcker");
            Console.WriteLine("3. Skriv ut info om en viss bok");
            Console.WriteLine("4. Ändra på info för en bok");
            Console.WriteLine("5. Ta bort en bok");
            Console.WriteLine("6. Avsluta programmet");
            var options = new JsonSerializerOptions { WriteIndented = true };
            // Tag in användarens input
            string input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    AddBook(); // Skapa en ny bok
                    jsonString = JsonSerializer.Serialize(allBooks, options);
                    File.WriteAllText("allbooks.json", jsonString);
                    break;
                case "2":
                    PrintAllBooks(); // Skriv ut alla böcker i listan
                    break;
                case "3":
                    PrintBookDetails(); // Skriv ut detaljer för en viss bok
                    break;
                case "4":
                    //ChangeBook(); // Ändra på info för en bok
                    jsonString = JsonSerializer.Serialize(allBooks, options);
                    File.WriteAllText("allbooks.json", jsonString);
                    break;
                case "5":
                    RemoveBook(); // Ta bort en bok
                    jsonString = JsonSerializer.Serialize(allBooks, options);
                    File.WriteAllText("allbooks.json", jsonString);
                    break;
                case "6": // Avsluta
                    Console.WriteLine("Tack för idag!");
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Du har skrivit fel, försök igen.");
                    break;
            }
            Console.ReadKey();
            Console.Clear();
        }
    }

    // AddBook. Adds a book to the list.
    public static void AddBook()
    {
        Console.Write("skriv titel:");
        string title = Console.ReadLine();
        Console.Write("skriv författare:");
        string author = Console.ReadLine();
        Console.Write("skriv kvalitet:");
        string quality = Console.ReadLine();
        Console.Write("skriv år:");
        int year = int.Parse(Console.ReadLine());
        Console.Write("skriv förlag:");
        string publisher = Console.ReadLine();
        Console.Write("Ange genre:");
        var values = Enum.GetValues(typeof(Genre));
        
        Console.WriteLine("Du har följande enums att välja på. Skriv in index:");
        for(int i = 0; i < values.Length; i++)
        {
            Console.WriteLine(i + ": " + Enum.GetName(typeof(Genre), i));
        }
        string genreChoice = Console.ReadLine();
        Genre genre = (Genre)int.Parse(genreChoice);

        try
        {
            allBooks.Add(new Book(title, author, quality, year, publisher, genre));
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    // PrintAllBooks. Skriver ut info om alla böcker. Men ej deras kvalitet.
    public static void PrintAllBooks()
    {
        // iterera igenom listan allBooks och skapa en temporär referens b (en bok)
        // till vardera instans i den listan.
        for(int i = 0; i < allBooks.Count; i++)
        {
            Book theBook = allBooks[i];
            // skriv ut info om varje bok
            Console.Write($"Index: {i},");
            Console.Write($"Title: {theBook.Title, -40}");
            Console.Write($"Author: {theBook.Author, -35}\t\t\t");
            Console.Write($"Year: {theBook.Year}");
            Console.Write($"Publisher: {theBook.Publisher, -20}");
            Console.Write($"Genre: {Enum.GetName(typeof(Genre), theBook.Genre)}\n");
        }
    }

    // PrintBookDetails. Skriver ut all info om en viss bok
    public static void PrintBookDetails()
    {
        PrintAllBooks();
        Console.Write("Ange index på den du vill se mer info om: ");
        int indexToGetInfo = int.Parse(Console.ReadLine());
        Book theBook = allBooks[indexToGetInfo];
        Console.WriteLine($"Title: {theBook.Title}");
        Console.WriteLine($"Author: {theBook.Author}");
        Console.WriteLine($"Year: {theBook.Year}");
        Console.WriteLine($"Publisher: {theBook.Publisher}");
        Console.WriteLine($"Quality: {theBook.Quality}");
        Console.WriteLine($"Genre: {Enum.GetName(typeof(Genre), theBook.Genre)}");
    }

    public static void RemoveBook()
    {
        PrintAllBooks();
        Console.Write("Ange index på den du vill ta bort: ");
        int indexToRemove = int.Parse(Console.ReadLine());
        allBooks.RemoveAt(indexToRemove);
    }
}

enum Genre
{
    Unknown,
    ScienceFiction,
    Fantasy,
    Crime,
    Drama,
    ComputerScience,
    Children
}
// Klassen Book håller reda på EN bok och endast EN.
class Book
{
    public string Title{get;set;}
    public string Author{get;set;}
    string quality;
    public int Year{set;get;}
    public string Publisher{get;set;}
    public Genre Genre{get;set;}

    // Här är en egenskap, Quality (stort Q). Den ska ändra på värdet på den privata
    // variabeln quality (litet q). Denna egenskap implementerar set- och get-.
    public string Quality
    {
        set
        {
            if (quality == "")
            {
                throw new ArgumentException("Du har skrivit fel någonstans.");
            }
            quality = value;
        }
        get
        {
            return quality;
        }
    }

    // konstruktor
    public Book(string title, string author, string quality, int year, string publisher, Genre genre)
    {
        if (title == "" || author == "" || quality == "" || year == 0 || publisher == "")
        {
            throw new ArgumentException("Du har skrivit fel någonstans.");
        }

        Title = title;
        Author = author;
        Quality = quality;
        Year = year;
        Publisher = publisher;
        Genre = genre;
    }
}