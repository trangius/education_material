// Förenkling av lambdan

class Program
{
    static void Main(string[] args)
    {
        // Skapa ett objekt av klassen Book
        Book b = new Book { Title = "Bröderna Lejonhjärta", Author = "Astrid Lindgren" };

        // Ännu simplare variant... magi!
        Action<Book> printBookTitle = book => Console.WriteLine(book.Title);

        // Anropa delegaten
        printBookTitle(b);
    }
}

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
}  
