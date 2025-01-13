using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;

class Student
{
	// Egenskaper i klassen som mappar till kolumnerna i databastabellen
	public int Id { get; set; }
	public string Name { get; set; }
	public string Email { get; set; }
	public DateTime DateOfBirth { get; set; }
}

class Server
{
    static void Main()
    {
        TcpListener listener = new TcpListener(IPAddress.Any, 9999);
        listener.Start();
        
        using (TcpClient client = listener.AcceptTcpClient())
        using (NetworkStream ns = client.GetStream())
        using (StreamReader reader = new StreamReader(ns, Encoding.UTF8))
        using (StreamWriter writer = new StreamWriter(ns, Encoding.UTF8) { AutoFlush = true })
        {
            bool running = true;
            while (running)
            {
                string line = reader.ReadLine();
                if (line == null)
                    break;
                
                if (line == "get_all_students")
                {
                    string sql = "SELECT Name, Email, DateOfBirth FROM Students";
                    string connectionString = File.ReadAllText("connectionString.txt");
		            using IDbConnection conn = new SqlConnection(connectionString);
                    IEnumerable<Student> students = conn.Query<Student>(sql);
                    string message = "list_of_students\n";
                    foreach (Student student in students)
                    {
                        message += $"s:{student.Name}:{student.Email}:{student.DateOfBirth}\n";
                    }
                    message += "end_of_student_list";
                    writer.WriteLine(message);
                    Console.WriteLine("message: " + message);
                }
                else if (line == "EXIT")
                {
                    running = false;
                }
            }
        }
        listener.Stop();
    }
}