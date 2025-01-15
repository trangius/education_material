using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

class Client
{
    static void Main()
    {
        using TcpClient client = new TcpClient("127.0.0.1", 9999);
        using NetworkStream ns = client.GetStream();
        using StreamReader reader = new StreamReader(ns, Encoding.UTF8);
        using StreamWriter writer = new StreamWriter(ns, Encoding.UTF8) { AutoFlush = true };
        while(true)
        {
            Console.WriteLine("1. List all students");
            Console.WriteLine("2. Add a student");
            Console.WriteLine("3. Delete a student");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    writer.WriteLine("get_all_students");

                    string response;
                    Console.WriteLine("List of students:");
                    while ((response = reader.ReadLine()) != null)
                    {
                        if (response == "end_of_student_list")
                        {
                            Console.WriteLine("... no more students ...");
                            break;
                        }

                        if (response.StartsWith("s:"))
                        {
                            string[] parts = response.Substring(2).Split(':');
                            string formatted = string.Join(", ", parts);
                            Console.WriteLine(formatted);
                        }
                    }
                    break;
                case "2":
                    Console.Write("Enter student name: ");
                    string name = Console.ReadLine();
                    string email = Console.ReadLine();
                    string dateofbirth = Console.ReadLine();
                    // skicka till servern
                    break;
                case "3":
                    Console.Write("Enter id: ");
                    string delete_id = Console.ReadLine();
                    // skicka till servern
                    break;
                case "4":
                    writer.WriteLine("exit");
                    return;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
