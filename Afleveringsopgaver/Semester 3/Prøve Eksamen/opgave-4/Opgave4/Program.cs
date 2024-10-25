
using System.Net;
using System.Net.Sockets;


Console.WriteLine("TCP Server");

// Start listening for incoming tcp connections
TcpListener listener = new TcpListener(IPAddress.Any, 7);
listener.Start();

while (true)
{
    // Accept a connection
    TcpClient socket = listener.AcceptTcpClient();
    Task.Run(() => HandleClient(socket)); // TODO: Not awaited
}

listener.Stop(); // TODO: Line is never reached

void HandleClient(TcpClient socket)
{
    // Get the network stream
    NetworkStream ns = socket.GetStream();

    // Create a reader and writer
    StreamReader reader = new StreamReader(ns);
    StreamWriter writer = new StreamWriter(ns);

    // Read and write data. Exit when the client sends "exit"
    bool keepListening = true;
    while (keepListening)
    {
        string? line = reader.ReadLine();
        Console.WriteLine("Received: " + line);
        writer.WriteLine("You wrote: " + line);
        writer.Flush();

        if (line != null && line.Equals("exit", StringComparison.OrdinalIgnoreCase))
        {
            keepListening = false;
        }
    }

    // Close the connection
    socket.Close();
}