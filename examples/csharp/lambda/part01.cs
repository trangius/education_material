// En delegat är en referens till en vanlig metod.

class Program
{
    static void Main(string[] args)
    {
        // Skapa ett objekt av klassen Book
        Book b = new Book { Title = "Bröderna Lejonhjärta", Author = "Astrid Lindgren" };

        // Skapa en delegat som pekar på metoden PrintBookTitle (notera små vs stora bokstäver)
        Action<Book> printBookTitle = PrintBookTitle;

        // Anropa delegaten
        printBookTitle(b);
    }

    // en helt vanlig metod
    static void PrintBookTitle(Book b)
    {
        Console.WriteLine(b.Title);
    }
}

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
}  
