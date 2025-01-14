using System.Net;
using System.Net.Sockets;
using System.Text;

class Server
{
    static void Main()
    {
        TcpListener listener = new TcpListener(IPAddress.Any, 9999);
        listener.Start();
        Console.WriteLine("Server is listening on port 9999...");
        using TcpClient client = listener.AcceptTcpClient();
        Console.WriteLine("Client connected.");
        using NetworkStream ns = client.GetStream();
        using StreamReader reader = new StreamReader(ns, Encoding.UTF8);
        using StreamWriter writer = new StreamWriter(ns, Encoding.UTF8) { AutoFlush = true };
        bool running = true;
        while (running)
        {
            string line = reader.ReadLine();
            if (line == null) break;
            if (line.StartsWith("msg "))
            {
                string msg = line.Substring(4);
                Console.WriteLine(msg);
            }
            else if (line == "exit")
            {
                running = false;
            }
        }
        listener.Stop();
    }
}
