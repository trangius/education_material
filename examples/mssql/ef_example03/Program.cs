
	static void PrintAllStudents()
	{
		// Skapar en instans av StudentContext för att interagera med databasen
		using var context = new SchoolContext();
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
