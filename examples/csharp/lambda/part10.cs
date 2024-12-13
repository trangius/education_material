// Och nu samma igen men med lambda
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

        // Sök efter alla böcker skrivna av Tolkien med hjälp av LINQ och lambda
        // jämför med part07.cs
        var tolkienBooks = FilterBooks(books, b => b.Author == "J.R.R. Tolkien");

        // Skriv ut böckerna av Tolkien
        foreach (var book in tolkienBooks)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}");
        }
    }

    // Vår egen filtermetod, istället för att använda LINQs Where-metod
    static List<Book> FilterBooks(List<Book> books, Func<Book, bool> criteria)
    {
        List<Book> result = new List<Book>();
        
        foreach (var book in books)
        {
            // Om boken uppfyller kriteriet, lägg till den i resultatet
            // här sker alltså själva anropet till delegaten.
            // Det är typ så här LINQs Where-metod fungerar i bakgrunden
            if (criteria(book))
            {
                result.Add(book);
            }
        }

        return result;
    }
}


class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
}
