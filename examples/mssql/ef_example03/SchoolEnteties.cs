public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; } 
    public DateTime DateOfBirth { get; set; }
}


public class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}


public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Credits { get; set; }  // Antal poäng
    public int TeacherId { get; set; }
}


public class Enrollment
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public DateTime EnrollmentDate { get; set; } 
    public int Grade { get; set; }  // Betyg (-1 - ej satt, 0 - IG, 1 - G, 2 - VG)

    public Student Student { get; set; }
    public Course Course { get; set; }
}
