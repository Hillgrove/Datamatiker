using System.Net.Sockets;

namespace EchoClient
{
    public class Client
    {
        public void Start()
        {
            using TcpClient socket = new TcpClient("localhost", 7);
            using NetworkStream ns = socket.GetStream();
            using StreamReader sr = new StreamReader(ns);
            using StreamWriter sw = new StreamWriter(ns);

            sw.WriteLine("Some random message");
            sw.Flush();

            string? line = sr.ReadLine();
            Console.WriteLine(line);
        }
    }
}
