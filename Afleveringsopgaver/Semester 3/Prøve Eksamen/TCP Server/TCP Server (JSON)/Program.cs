
using System.Net;
using System.Net.Sockets;
using System.Text.Json;

Console.WriteLine("TCP Server");

// Listens for incoming connections and starts a new task for each client
TcpListener listener = new TcpListener(IPAddress.Any, 1337);
listener.Start();

while (true)
{
    TcpClient socket = listener.AcceptTcpClient();
    Task.Run(() => HandleClient(socket)); // TODO: Not awaited
}

void HandleClient(TcpClient socket)
{
    // Streams for reading and writing to the connection/socket
    NetworkStream ns = socket.GetStream();
    StreamReader reader = new StreamReader(ns);
    StreamWriter writer = new StreamWriter(ns) { AutoFlush = true };

    Console.WriteLine("Debug: Client connected.");

    while (socket.Connected)
    {
        // Read JSON message from client
        string? message = reader.ReadLine();
        Console.WriteLine($"Debug: Received: {message}");

        // Client lost connection
        if (message == null)
        {
            Console.WriteLine("Debug: Client lost connection!");
            socket.Close();
            break;
        }

        // Parse JSON request
        Request request;
        try
        {
            request = JsonSerializer.Deserialize<Request>(message);
            if (request == null || string.IsNullOrEmpty(request.Method))
            {
                throw new Exception("Invalid request");
            }
        }
        catch (Exception)
        {
            // Send error response if JSON is invalid
            var errorResponse = new Response { Error = "Invalid request format" };
            string errorJson = JsonSerializer.Serialize(errorResponse);
            writer.WriteLine(errorJson);
            continue;
        }

        // Handle the request based on the method
        Response response = new Response();
        switch (request.Method.ToLower())
        {
            case "random":
                try
                {
                    Random random = new Random();
                    int randomNumber = random.Next(request.NumberX, request.NumberY);
                    response.Result = $"Random number: {randomNumber}";
                }
                catch (Exception ex)
                {
                    response.Error = $"Error generating random number: {ex.Message}";
                }
                break;

            case "add":
                response.Result = $"Sum: {request.NumberX + request.NumberY}";
                break;

            case "subtract":
                response.Result = $"Difference: {request.NumberX - request.NumberY}";
                break;

            case "stop":
                response.Result = "Closing down connection!";
                string responseJson = JsonSerializer.Serialize(response);
                writer.WriteLine(responseJson);
                socket.Close();
                return;

            default:
                response.Error = "Invalid method. Please try again.";
                break;
        }

        // Send JSON response back to the client
        string jsonResponse = JsonSerializer.Serialize(response);
        writer.WriteLine(jsonResponse);
    }

    // Close the connection
    socket.Close();
}

// Define request and response classes for JSON serialization
public class Request
{
    public string Method { get; set; }
    public int NumberX { get; set; }
    public int NumberY { get; set; }
}

public class Response
{
    public string Result { get; set; }
    public string Error { get; set; }
}