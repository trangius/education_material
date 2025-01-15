using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

class Client
{
    static void Main()
    {
        using TcpClient client = new TcpClient("192.168.0.145", 9999);
        using NetworkStream ns = client.GetStream();
        using StreamWriter writer = new StreamWriter(ns, Encoding.UTF8) { AutoFlush = true };
    
        writer.WriteLine("msg hej");
        writer.WriteLine("msg kalle");
        writer.WriteLine("msg apa");
        writer.WriteLine("exit");
    }
}
