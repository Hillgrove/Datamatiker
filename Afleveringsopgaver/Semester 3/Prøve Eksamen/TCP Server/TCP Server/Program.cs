
using System.Net;
using System.Net.Sockets;

Console.WriteLine("TCP Server");

// Listens for incoming connections and starts a new task for each client
TcpListener listener = new TcpListener(IPAddress.Any, 7);
listener.Start();

while (true)
{
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

    Console.WriteLine("Debug: Client connected.");
    // Sadly deadlocks the interaction between the Client and Server
    //writer.WriteLine("You're now connected to the TCP Server.");
    //writer.Flush();

    while (socket.Connected)
    {
        // Read message from client
        string? message = reader.ReadLine();
        Console.WriteLine($"Debug: Client sent: {message}");

        // Client lost connection
        if (message == null) 
        {
            Console.WriteLine($"Debug: Client lost connection!");
            socket.Close();
            break;
        }

        // Sanitize message
        message = message.Trim().ToLower();

        // Client stopped connection
        if (message == "stop")
        {
            Console.WriteLine($"Debug: Client stopped connection!");
            writer.WriteLine("Closing down connection!");
            writer.Flush();
            socket.Close();
            break;
        }

        int numberX = 0;
        int numberY = 0;

        // Check if message is a command that requires numbers
        if (message == "random" || message == "add" || message == "subtract")
        {
            writer.WriteLine($"Input numbers");
            writer.Flush();

            string? numbers = reader.ReadLine();

            if (numbers == null)
            {
                Console.WriteLine($"Debug: Client lost connection!");
                socket.Close();
                break;
            }

            // Sanitize input
            try
            {
                int[] nums = numbers.Split(' ').Select(int.Parse).ToArray();
                numberX = nums[0];
                numberY = nums[1];
            }
            catch (Exception) // catch-all
            {
                writer.WriteLine("Invalid input. Please input two numbers seperated by a space.");
                writer.Flush();
                continue;
            }
        }

        // Handle message
        switch (message)
        {
            case "random":
                Random random = new Random();
                int randomNumber = random.Next(numberX, numberY);
                writer.WriteLine($"Random number: {randomNumber}");
                break;

            case "add":
                int sum = numberX + numberY;
                writer.WriteLine($"Sum: {sum}");
                break;

            case "subtract":
                int difference = numberX - numberY;
                writer.WriteLine($"Difference: {difference}");
                break;

            default:
                writer.WriteLine("Invalid command. Please try again.");
                break;
        }

        writer.Flush();
    }

    // Close the connection
    socket.Close();
}