using Microsoft.EntityFrameworkCore;	 // Innehåller klasser för Entity Framework Core

// Studentklass som motsvarar EN RAD i databastabellen 'Students'
public class Student
{
	// Egenskaper i klassen som mappar till kolumnerna i databastabellen
	public int Id { get; set; }
	public string Name { get; set; }
	public string Email { get; set; }
	public DateTime DateOfBirth { get; set; }
}

// DbContext för Entity Framework, representerar en session med databasen
public class StudentContext : DbContext
{
	// Objekt av klassen. Representerar tabellen 'Students' i databasen.
	// Via denna kan vi sedan hämta ut, lägga till och ta bort data i databasen
	public DbSet<Student> Students { get; set; }

	// Konfigurerar databaskopplingen
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		// Anslutningssträng för att ansluta till SQL Server-databasen
		optionsBuilder.UseSqlServer(
			"Server=gondolin667.org;" +
			"Database=yourdatabasename;" +
			"User ID=yourusername;" +
			"Password=yourpassword;" +
			"Encrypt=False;" +
			"TrustServerCertificate=False;"
		);
	}
}

class Program
{
	static void Main(string[] args)
	{
		// Skapar en ny instans av StudentContext, vilket representerar en session med databasen
		using var context = new StudentContext();

		// =================================== SELECT ===================================
		// Hämta alla studenter från databasen som en lista
		// Bakom kulisserna översätter Entity Framework denna fråga till SQL:
		//		SELECT s.Id, s.Name, s.Email, s.DateOfBirth
		//		FROM Students AS s
		List<Student> students = context.Students.ToList();

		// Itererar över varje student i listan (som nyss hämtades ur databasen) och skriver ut deras information
		foreach (var student in students)
		{
			Console.WriteLine(
				$"Id: {student.Id}, " +
				$"Namn: {student.Name}, " +
				$"E-post: {student.Email}, " +
				$"Född: {student.DateOfBirth.ToShortDateString()}"
			);
		}


		// =================================== INSERT ===================================
		// Frågar användaren om information för den nya studenten
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

		// Skapar en ny student med användarens inmatning
		var newStudent = new Student
		{
			Name = name,
			Email = email,
			DateOfBirth = dateOfBirth
		};

		context.Students.Add(newStudent); // Denna lägger till studenten i RAM-minnet

		context.SaveChanges(); // Denna skriver ändringarna till databasen
		// Bakom kulisserna översätter Entity Framework denna operation till SQL:
		//		INSERT INTO Students (Name, Email, DateOfBirth)
		//		VALUES (@p0, @p1, @p2);
		// Där @p0, @p1, @p2 motsvarar värdena för namn, e-post och födelsedatum

		Console.WriteLine("Studenten har lagts till i databasen.");
	}
}
