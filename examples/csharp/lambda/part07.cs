// Låt oss ta samma exempel men med delgat istället för lambda
class Program
{
    static void Main(string[] args)
    {
        // Skapa en lista med 30 böcker
        List<Book> books = new List<Book>
        {
            new Book { Title = "The Return of the King", Author = "J.R.R. Tolkien" },
            new Book { Title = "1984", Author = "George Orwell" },
            new Book { Title = "Animal Farm", Author = "George Orwell" },
            new Book { Title = "The Hobbit", Author = "J.R.R. Tolkien" },
            new Book { Title = "Brave New World", Author = "Aldous Huxley" },
            new Book { Title = "Dune", Author = "Frank Herbert" },
            new Book { Title = "Foundation", Author = "Isaac Asimov" },
            new Book { Title = "Neuromancer", Author = "William Gibson" },
            new Book { Title = "Fahrenheit 451", Author = "Ray Bradbury" },
            new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald" },
            new Book { Title = "Moby Dick", Author = "Herman Melville" },
            new Book { Title = "Dracula", Author = "Bram Stoker" },
            new Book { Title = "Frankenstein", Author = "Mary Shelley" },
            new Book { Title = "War and Peace", Author = "Leo Tolstoy" },
            new Book { Title = "Crime and Punishment", Author = "Fyodor Dostoevsky" },
            new Book { Title = "Pride and Prejudice", Author = "Jane Austen" },
            new Book { Title = "The Catcher in the Rye", Author = "J.D. Salinger" },
            new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee" },
            new Book { Title = "Harry Potter and the Philosopher's Stone", Author = "J.K. Rowling" },
            new Book { Title = "The Two Towers", Author = "J.R.R. Tolkien" },
            new Book { Title = "Harry Potter and the Chamber of Secrets", Author = "J.K. Rowling" },
            new Book { Title = "The Hunger Games", Author = "Suzanne Collins" },
            new Book { Title = "The Da Vinci Code", Author = "Dan Brown" },
            new Book { Title = "The Fellowship of the Ring", Author = "J.R.R. Tolkien" },
            new Book { Title = "The Road", Author = "Cormac McCarthy" },
            new Book { Title = "Gone Girl", Author = "Gillian Flynn" },
            new Book { Title = "The Silmarillion", Author = "J.R.R. Tolkien" },
        };

        // Sök efter alla böcker skrivna av Tolkien med hjälp av LINQ och delegat
        var tolkienBooks = books.Where(delegate(Book b) {return b.Author == "J.R.R. Tolkien";}).ToList();

        // Skriv ut böckerna av Tolkien
        foreach (var book in tolkienBooks)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}");
        }
    }
}

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
}
