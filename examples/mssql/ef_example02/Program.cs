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
		bool exit = false;

		while (!exit)
		{
			// Visa meny för användaren
			Console.WriteLine("\nVälj ett alternativ:");
			Console.WriteLine("1. Lägg till en ny student");
			Console.WriteLine("2. Uppdatera en student");
			Console.WriteLine("3. Lista alla studenter");
			Console.WriteLine("4. Avsluta");

			// Läs in användarens val
			string choice = Console.ReadLine();

			switch (choice)
			{
				case "1":
					InsertStudent();
					break;
				case "2":
					UpdateStudent();
					break;
				case "3":
					PrintAllStudents();
					break;
				case "4":
					exit = true;
					break;
				default:
					Console.WriteLine("Ogiltigt val, försök igen.");
					break;
			}
		}
	}

	static void InsertStudent()
	{
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

		using var context = new StudentContext();
		context.Students.Add(newStudent); // Denna lägger till studenten i RAM-minnet
		
		context.SaveChanges(); // Denna skriver ändringarna till databasen
		// Bakom kulisserna översätter Entity Framework denna operation till SQL:
		//		INSERT INTO Students (Name, Email, DateOfBirth)
		//		VALUES (@p0, @p1, @p2);
		// Där @p0, @p1, @p2 motsvarar värdena för namn, e-post och födelsedatum

		Console.WriteLine("Studenten har lagts till i databasen.");
	}

	static void UpdateStudent()
	{
		// Frågar användaren om studentens ID att uppdatera
		Console.WriteLine("Ange ID för den student du vill uppdatera:");
		int id;
		while (!int.TryParse(Console.ReadLine(), out id))
		{
			Console.WriteLine("Ogiltigt ID, försök igen:");
		}

		using var context = new StudentContext();
		// Hämtar studenten från databasen
		var studentToUpdate = context.Students.FirstOrDefault(s => s.Id == id);
		if (studentToUpdate != null)
		{
			// Frågar användaren om ny information
			Console.WriteLine("Ange nytt namn (lämna tomt för att behålla nuvarande):");
			string name = Console.ReadLine();
			if (!string.IsNullOrEmpty(name))
				studentToUpdate.Name = name; // denna ändrar i RAM

			Console.WriteLine("Ange ny e-post (lämna tomt för att behålla nuvarande):");
			string email = Console.ReadLine();
			if (!string.IsNullOrEmpty(email))
				studentToUpdate.Email = email; // denna ändrar i RAM

			Console.WriteLine("Ange nytt födelsedatum (åååå-mm-dd, lämna tomt för att behålla nuvarande):");
			string dobInput = Console.ReadLine();
			if (!string.IsNullOrEmpty(dobInput))
			{
				DateTime dateOfBirth;
				if (DateTime.TryParse(dobInput, out dateOfBirth))
				{
					studentToUpdate.DateOfBirth = dateOfBirth; // denna ändrar i RAM
				}
				else
				{
					Console.WriteLine("Ogiltigt datumformat, födelsedatum uppdaterades inte.");
				}
			}

			// Sparar ändringarna i databasen
			context.SaveChanges(); // Denna sparar ändringarna i databasen
			// Bakom kulisserna översätter Entity Framework denna operation till SQL:
			//		UPDATE Students
			//		SET Name = @p0, Email = @p1, DateOfBirth = @p2
			//		WHERE Id = @p3;
			// Där @p0, @p1, @p2 är de nya värdena och @p3 är studentens Id
			Console.WriteLine("Studenten har uppdaterats.");
		}
		else
		{
			Console.WriteLine("Ingen student med angivet ID hittades.");
		}
	}

	static void PrintAllStudents()
	{
		// Skapar en instans av StudentContext för att interagera med databasen
		using var context = new StudentContext();
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
	}
}
