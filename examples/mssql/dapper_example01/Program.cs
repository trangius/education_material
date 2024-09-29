// använd viktiga bibliotek för att Dapper ska funka
using System.Data;
using System.Data.SqlClient;
using Dapper;

// Skapa en klass som ska mappa mot tabellen Person i databasen
public class Student
{
	// Egenskaper i klassen som mappar till kolumnerna i databastabellen
	public int Id { get; set; }
	public string Name { get; set; }
	public string Email { get; set; }
	public DateTime DateOfBirth { get; set; }
}


class Program
{
	static void Main()
	{
		// Skapa en anslutning
		using IDbConnection connection = new SqlConnection(
				"Server=gondolin667.org;" +
				"Database=yourdatabasename;" +
				"User ID=yourusername;" +
				"Password=yourpassword;" +
				"Encrypt=False;" +
				"TrustServerCertificate=False;"
);

		// =================================== SELECT ===================================
		// Kod för att skriva ut alla personer från tabellen.
		// Vi börjar med att hämta ut ett result set med en SELECT-sats:
		IEnumerable<Student> result = connection.Query<Student>("SELECT * FROM Students");
		//List<Person> persons = result.ToList(); // nödvändig om vi vill manipulera den som en Lista

		// Loopa igenom result, result är inte kopplad mot databasen utan finns nu i RAM
		foreach (Student s in result)
		{
			Console.WriteLine($"Id: {s.Id}, Namn: {s.Name}, Email:	{s.Email} on {s.DateOfBirth}");
		}


		// =================================== INSERT ===================================
		// Kod för att lägga till en person i databasen.
		// Börja med att läsa in data från användaren:
		Console.WriteLine("Ange studentens namn:");
		string name = Console.ReadLine();

		Console.WriteLine("Ange studentens e-post:");
		string email = Console.ReadLine();

		Console.WriteLine("Ange studentens födelsedatum (åååå-mm-dd):");
		DateTime dateOfBirth;
		while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
		{
			Console.WriteLine("Ogiltigt datumformat, försök igen (åååå-mm-dd):");
		}

		// Skapa en SQL-query 
		// Vi börjar med att skapa en vanlig textsträng.
		string sqlcode = $"INSERT INTO Students(Name, Email, DateOfBirth) VALUES ('{name}', '{email}', '{dateOfBirth}')";
		
		// Denna textsträng kan vi skriva ut om nåt knasar, sen kan vi testa den direkt i t.ex. Azure Data Studio
		// Ha för vana att alltid göra detta om något inte funkar som det ska!
		//Console.WriteLine(sqlcode);
		
		// När vi gör INSERT, UPDATE, DELETE etc så använder vi dapper- metoden Execute() istället för Query()
		// Execute ger oss information om hur många rader vi har påverkat. Denna skickar alltså själva queryn via nätet
		// till databasservern som vi är ansluten mot. Där kör sen queryn och en person läggs in i databasen.
		int count = connection.Execute(sqlcode);
		Console.WriteLine($"{count} rows affected.");


		// =================================== DELETE ===================================
		/*
		// Ta bor en person från databasen:
		var removed = connection.Execute("delete from People where Name = @name", new {name} );
		Console.WriteLine($"Removed {removed} rows.");
		*/
	}
}
