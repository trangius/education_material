// använd viktiga bibliotek för att Databasanslutning och Dapper ska funka
class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
}

class Course
{
    public int Id{get;set;}
    public string Name {get;set;}
    public int Credits{get;set;}
    public string Teacher {get;set;}
}

class Programmmmmmmm
{
    static void Main()
    {
        DatabaseRepository repo = new DatabaseRepository();

        // List<(string Name, double AverageGrade)> avgGrades = repo.GetAverageGradeForAllCourses();
        // foreach(var avgGrade in avgGrades)
        // {
        //     Console.WriteLine($"Kurs: {avgGrade.Name}, Medelbetyg: {avgGrade.AverageGrade}");
        // }
        // List<Student> students = repo.GetAllStudents();
        // foreach (Student student in students)
        // {
        //     Console.WriteLine($"Namn: {student.Name}, E-post: {student.Email}, Födelsedatum: {student.DateOfBirth}");
        // }

        // Console.Write("Vilken student vill du se? (Ange ID):");
        // int id = int.Parse(Console.ReadLine());
        // Student aStudent = repo.GetStudentById(id);
        // Console.WriteLine($"Namn: {aStudent.Name}, E-post: {aStudent.Email}, Födelsedatum: {aStudent.DateOfBirth}");
        
        Console.Write("Ange namn: ");
        string name = Console.ReadLine();
        
        Console.Write("Ange Email: ");
        string email = Console.ReadLine();
        
        Console.Write("Ange Födelsedatum: ");
        string date = Console.ReadLine();

        // registrera student till en kurs:
        
        // skriv först ut alla kurser:
        List<Course> courses = repo.GetAllCourses();
        foreach (Course course in courses)
        {
            Console.WriteLine($"Id:{course.Id} Kurs: {course.Name}, Lärare: {course.Teacher}, Poäng: {course.Credits}");
        }
        Console.Write("Vilken kurs vill du registrera studenten till? (Ange ID): ");
        int courseId = int.Parse(Console.ReadLine());

        try
        {
            repo.AddStudent(name, email, date, courseId);
            Console.WriteLine("Student tillagd!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Fel: " + ex.Message);
        } 

    }
}
