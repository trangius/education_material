using System.Data;
using System.Data.SqlClient;
using Dapper;
class DatabaseRepository
{
    public IDbConnection Connect()
    {
        string connectionString = File.ReadAllText("connectionString.txt");
        return new SqlConnection(connectionString);
    }

    public List<Student> GetAllStudents()
    {
        string sql = "SELECT Name, Email, DateOfBirth FROM Students";
        using IDbConnection conn = Connect();
        return conn.Query<Student>(sql).AsList();
    }

    public List<Course> GetAllCourses()
    {
        string sql = "SELECT c.Id as Id, c.Name, c.Credits, t.Name as Teacher FROM Courses c INNER JOIN Teachers t ON c.TeacherId = t.Id";
        using IDbConnection conn = Connect();
        return conn.Query<Course>(sql).AsList();
    }

    public Student GetStudentById(int id)
    {
        string sql = "SELECT Name, Email, DateOfBirth FROM Students WHERE id=" + id;
        //Console.WriteLine(sql);
        using IDbConnection conn = Connect();
        return conn.QuerySingle<Student>(sql);
    }

    public void AddStudent(string name, string email, string date, int courseId)
    {
        using IDbConnection conn = Connect();
        conn.Open(); // behövs för att kunna använda transaktioner
        using var transaction = conn.BeginTransaction();
        try
        {
            // Lägg till student och hämta tillbaka det genererade Id:t
            string sqlInsertStudent = "INSERT INTO Students (Name, Email, DateOfBirth) OUTPUT INSERTED.Id VALUES (@Name, @Email, @DateOfBirth)";
            int studentId = conn.QuerySingle<int>(
                sqlInsertStudent, 
                new { Name = name, Email = email, DateOfBirth = date }, 
                transaction);

            // Lägg till i Enrollments-tabellen
            string sqlInsertEnrollment = "INSERT INTO Enrollments (StudentId, CourseId, EnrollmentDate) VALUES (@StudentId, @CourseId, @EnrollmentDate)";
            conn.Execute(
                sqlInsertEnrollment, 
                new { StudentId = studentId, CourseId = courseId, EnrollmentDate = DateTime.Now }, 
                transaction);

            // Bekräfta transaktionen
            transaction.Commit();
        }
        catch (Exception ex)
        {
            // Ångra om något går fel
            transaction.Rollback();
            Console.WriteLine($"Error: {ex.Message}. Transaction rolled back.");
        }
    }

    public List<(string Name, double AverageGrade)> GetAverageGradeForAllCourses()
    {
        string sql = @"SELECT Courses.Name, AVG(CAST(Enrollments.Grade AS FLOAT)) AS AverageGrade
                        FROM Courses
                        JOIN Enrollments ON Courses.Id = Enrollments.CourseId
                        GROUP BY Courses.Id, Courses.Name;";
        using IDbConnection conn = Connect();
        return conn.Query<(string Name, double AverageGrade)>(sql).AsList();
    }
}
