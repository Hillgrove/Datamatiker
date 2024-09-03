
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
    Task.Run(() => HandleClient(socket));
}

// Stopping server
listener.Stop();  // Currently not reached


void HandleClient(TcpClient socket)
{
    // Streams for reading and writing to the connection/socket
    NetworkStream ns = socket.GetStream();
    StreamReader reader = new StreamReader(ns);
    StreamWriter writer = new StreamWriter(ns);

    bool socketActive = true;
    while (socketActive)
    {
        // Reading what the client sends
        string message = reader.ReadLine();
        Console.WriteLine($"Client sent: {message}"); // for debugging purposes

        if (message == "quit")
        {
            socketActive = false;
            Console.WriteLine($"Debug: Closing down connection!"); // for debugging purposes
            writer.WriteLine("Closing down connection!");
            writer.Flush();
            break;
        }

        // Writing back/echo to the client
        writer.WriteLine(message.ToUpper());
        writer.Flush();
    }

    // Close connection/socket and stop listener
    socket.Close();
}