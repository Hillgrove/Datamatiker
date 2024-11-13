
using System.Net;
using System.Net.Sockets;

Console.WriteLine("TCP Server");

// Listens for incomming connections
TcpListener listener = new TcpListener(IPAddress.Any, 7);

// Starting server
listener.Start();

while (true)
{
    // Establish connection/socket
    TcpClient socket = listener.AcceptTcpClient();
    Task.Run(() => HandleClient(socket)); // TODO: Not awaited
}

// Stopping server
listener.Stop();  // TODO: Unreachable code


void HandleClient(TcpClient socket)
{
    // Streams for reading and writing to the connection/socket
    NetworkStream ns = socket.GetStream();
    StreamReader reader = new StreamReader(ns);
    StreamWriter writer = new StreamWriter(ns);

    while (socket.Connected)
    {
        // Reading what the client sends
        string? message = reader.ReadLine();
        Console.WriteLine($"Client sent: {message}"); // for debugging purposes

        if (message == "stop")
        {
            Console.WriteLine($"Debug: Closing down connection!"); // for debugging purposes
            writer.WriteLine("Closing down connection!");
            writer.Flush();
            socket.Close();
        }

        // Writing back/echo to the client
        writer.WriteLine(message.ToUpper());
        writer.Flush();
    }

    // Close connection/socket and stop listener
    socket.Close();
}