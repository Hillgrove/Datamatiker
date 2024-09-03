
using System.Net;
using System.Net.Sockets;

Console.WriteLine("TCP Server");
Console.WriteLine("""Type "quit" to shutdown server.""");

// Listens for incomming connections
TcpListener listener = new TcpListener(IPAddress.Any, 7);
listener.Start();

// Establish connection/socket
TcpClient socket = listener.AcceptTcpClient();

// Streams for reading and writing to the connection/socket
NetworkStream ns = socket.GetStream();
StreamReader reader = new StreamReader(ns);
StreamWriter writer = new StreamWriter(ns);

bool serverRunning = true;
while (serverRunning)
{
    // Reading what the client sends
    string message = reader.ReadLine();
    Console.WriteLine($"Debug: {message}"); // for debugging purposes

    if (message == "quit")
    {
        serverRunning = false;
        Console.WriteLine($"Debug: Shutting down server!"); // for debugging purposes
        writer.WriteLine("Shutting down server!");
        writer.Flush();
        break;
    }

    // Writing back/echo to the client
    writer.WriteLine(message);
    writer.Flush();

}

// Close connection/socket and stop listener
socket.Close();
listener.Stop();