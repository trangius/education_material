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
        using StreamWriter writer = new StreamWriter(ns, Encoding.UTF8) { AutoFlush = true };

        while(true)
        {
            string myMessage = Console.ReadLine(); 
            if(myMessage == "exit")
            {
                writer.WriteLine("exit");
                break;
            }
            writer.WriteLine("msg krister: " + myMessage);
        }
    }
}
