class Program
{
    static void Main(string[] args)
    {
        // Gör så att vi kan skicka in en Book som parameter
        Action<Book> myAction = delegate(Book b)
        {
            Console.WriteLine(b.Author);
            Console.WriteLine(b.Title);
        };

        // Anropa delegaten
        myAction(new Book { Author = "J.R.R. Tolkien", Title = "The Silmarillion" });
        myAction(new Book { Author = "Mary Shelley", Title = "Frankenstein" });
    }
}

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
}