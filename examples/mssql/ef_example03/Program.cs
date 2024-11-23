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
            Console.WriteLine("4. Visa studenters betyg för en viss kurs");
            Console.WriteLine("5. Visa alla kurser för en lärare");
            Console.WriteLine("6. Lista alla kurser (ID och namn)");
            Console.WriteLine("7. Lista alla kurser (endast namn)");
            Console.WriteLine("8. Visa fullständig information om alla kurser");
            Console.WriteLine("9. Avsluta");

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
                    Console.Clear();
                    Console.WriteLine("============ Kurser =============");
                    PrintCourseAllInfo();
                    Console.WriteLine("=================================");
                    Console.Write("Ange kursens ID för att visa studenternas betyg:");
                    int courseId = CHelp.ReadInt();
                    PrintAllStudentsInCourse(courseId);
                    break;
                case "5":
                    Console.Write("Ange lärarens ID:");
                    int teacherId = CHelp.ReadInt();
                    PrintAllCoursesForTeacher(teacherId);
                    break;
                case "6":
                    PrintCoursesNameAndId();
                    break;
                case "7":
                    PrintCoursesName();
                    break;
                case "8":
                    PrintCourseAllInfo();
                    break;
                case "9":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Ogiltigt val, försök igen.");
                    break;
            }
        }
    }

	static void PrintAllStudents()
	{
		// Skapar en instans av StudentContext för att interagera med databasen
		// Hämta alla studenter från databasen som en lista
		using var context = new SchoolContext();
		IEnumerable<Student> students = context.Students;
		        

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

	static void InsertStudent()
	{
		// Frågar användaren om information för den nya studenten
		Console.WriteLine("Ange studentens namn:");
		string name = CHelp.ReadString();

		Console.WriteLine("Ange studentens e-post:");
		string email = CHelp.ReadString();

		Console.WriteLine("Ange studentens födelsedatum (åååå-mm-dd):");
		DateTime dateOfBirth = CHelp.ReadDate();

		// Skapar en ny student med användarens inmatning
		var newStudent = new Student
		{
			Name = name,
			Email = email,
			DateOfBirth = dateOfBirth
		};

		using var context = new SchoolContext();
		context.Students.Add(newStudent); // Denna lägger till studenten i RAM-minnet. Lokalt. Ej i databasen än.
		context.SaveChanges(); // Denna skriver ändringarna till databasen
		Console.WriteLine("Studenten har lagts till i databasen.");
	}

	static void UpdateStudent()
	{
		// Frågar användaren om studentens ID att uppdatera
		Console.WriteLine("Ange ID för den student du vill uppdatera:");
		int id = CHelp.ReadInt();

		using var context = new SchoolContext();

		// Hämtar studenten från databasen
        Student studentToUpdate = context.Students.Find(id);
		if (studentToUpdate == null)
		{
			Console.WriteLine("Ingen student med angivet ID hittades.");
            return;
        }
 
        // Frågar användaren om ny information och uppdatera i studentobjektet
        // detta sker just nu bara i RAM
        Console.WriteLine("Ange nytt namn (lämna tomt för att behålla nuvarande):");
        studentToUpdate.Name = CHelp.ReadString();
        Console.WriteLine("Ange ny e-post (lämna tomt för att behålla nuvarande):");
        studentToUpdate.Email = CHelp.ReadString();
        Console.WriteLine("Ange nytt födelsedatum (åååå-mm-dd, lämna tomt för att behålla nuvarande):");
        studentToUpdate.DateOfBirth = CHelp.ReadDate();

        // Sparar ändringarna i databasen
        context.SaveChanges(); // Denna sparar ändringarna i databasen
        Console.WriteLine("Studenten har uppdaterats.");
	}

    public static void PrintCourseAllInfo()
    {
        using var context = new SchoolContext();
        IEnumerable<Course> courses = context.Courses.ToList();

        foreach (var course in courses)
        {
            Console.WriteLine($"ID: {course.Id}, Name: {course.Name}, Credits: {course.Credits}, TeacherId: {course.TeacherId}");
        }
    }

    public static void PrintCoursesNameAndId()
    {
        using var context = new SchoolContext();
        //var courses = context.Courses.Select(c => new { c.Id, c.Name }); // skapar en anonym typ med Id och Name
        var courses = from c in context.Courses select new { c.Id, c.Name };
        foreach (var course in courses)
        {
            Console.WriteLine($"ID: {course.Id}, Name: {course.Name}");
        }
    }

    public static void PrintCoursesName()
    {
        using var context = new SchoolContext();
        // IEnumerable<string> courseNames = context.Courses.Select(c => c.Name); // skapar en lista med namn, bara string
        IEnumerable<string> courseNames = from c in context.Courses select c.Name; // skapar en lista med namn, bara string

        foreach (var name in courseNames)
        {
            Console.WriteLine($"Name: {name}");
        }
    }


    static void PrintAllCoursesForTeacher(int teacherId)
    {
        using var context = new SchoolContext();
        // var coursesForTeacher = context.Courses
        //     .Where(c => c.TeacherId == teacherId)
        //     .Select(c => new
        //     {
        //          CourseName = c.Name,
        //          CourseId = c.Id
        //     });

        var coursesForTeacher = from c in context.Courses
            where c.TeacherId == teacherId
            select new {CourseName = c.Name, CourseId = c.Id};

        foreach (var course in coursesForTeacher)
        {
            Console.WriteLine($"Kurs: {course.CourseName}, ID: {course.CourseId}");
        }
    }
    
    static void PrintAllStudentsInCourse(int courseId)
    {
        using var context = new SchoolContext();
        //     var studentsInCourse = context.Enrollments
        // .Where(e => e.CourseId == courseId)
        // .Select(e => new
        // {
        //     StudentName = e.Student.Name,
        //     Grade = e.Grade
        // });

        var studentsInCourse = from e in context.Enrollments
        where e.CourseId == courseId
        select new
        {
            StudentName = e.Student.Name,
            Grade = e.Grade
        };

        foreach(var item in studentsInCourse)
        {
            // switch (item.Grade) to unset/IG/G/VG
            string strGrade = item.Grade switch
            {
                0 => "Ej satt",
                1 => "IG",
                2 => "G",
                3 => "VG",
                _ => "Okänt"
            };
            Console.WriteLine($"Student: {item.StudentName}, Betyg: {strGrade}");
        }
    }
}
