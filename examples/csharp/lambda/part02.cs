// En delegat som skapas anonymt
class Program
{
    static void Main(string[] args)
    {
        // Skapa ett objekt av klassen Book
        Book b = new Book { Title = "Bröderna Lejonhjärta", Author = "Astrid Lindgren" };

        // Skapa en anonym delegat.
        Action<Book> printBookTitle = delegate (Book book)
        {
            Console.WriteLine(book.Title);
        };

        // Anropa delegaten
        printBookTitle(b);
    }
}

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
}  
