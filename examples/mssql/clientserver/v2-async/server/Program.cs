using System.Net;
using System.Net.Sockets;
using System.Text;

class Server
{
    static async Task Main()
    {
        TcpListener listener = new TcpListener(IPAddress.Any, 9999);
        listener.Start();
//        Console.WriteLine("Server is listening on port 9999...");

        var clients = new List<Task>();

        while (true)
        {
            TcpClient client = await listener.AcceptTcpClientAsync();
 //           Console.WriteLine("Client connected.");
            clients.Add(HandleClientAsync(client));
        }
    }

    static async Task HandleClientAsync(TcpClient client)
    {
        try
        {
            using NetworkStream ns = client.GetStream();
            using StreamReader reader = new StreamReader(ns, Encoding.UTF8);
            bool running = true;

            while (running)
            {
                string? line = await reader.ReadLineAsync();
                if (line == null)
                    break;

                if (line.StartsWith("msg "))
                {
                    string whatTheClientSays = line.Substring(4);
                    Console.WriteLine(whatTheClientSays);
                }
                else if (line == "exit")
                {
                    running = false;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error handling client: {ex.Message}");
        }
        finally
        {
            client.Close();
  //          Console.WriteLine("Client disconnected.");
        }
    }
}
