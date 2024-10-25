
using System.Net.Sockets;
using System.Text.Json;

Console.WriteLine("TCP Client");

TcpClient socket = new TcpClient("127.0.0.1", 1337);
NetworkStream ns = socket.GetStream();
StreamReader reader = new StreamReader(ns);
StreamWriter writer = new StreamWriter(ns) { AutoFlush = true };

while (socket.Connected)
{
    // Prompt user for method
    string method = Console.ReadLine().Trim().ToLower();

    int numberX = 0;
    int numberY = 0;

    if (method == "random" || method == "add" || method == "subtract")
    {
        // Prompt user for numbers
        Console.WriteLine("Enter number X:");
        if (!int.TryParse(Console.ReadLine(), out numberX))
        {
            Console.WriteLine("Invalid input for number X.");
            continue;
        }

        Console.WriteLine("Enter number Y:");
        if (!int.TryParse(Console.ReadLine(), out numberY))
        {
            Console.WriteLine("Invalid input for number Y.");
            continue;
        }
    }

    // Create and serialize the request to JSON
    var request = new Request
    {
        Method = method,
        NumberX = numberX,
        NumberY = numberY
    };
    string jsonRequest = JsonSerializer.Serialize(request);

    // Send the JSON request to the server
    writer.WriteLine(jsonRequest);

    // Read and deserialize the JSON response from the server
    string jsonResponse = reader.ReadLine();
    var response = JsonSerializer.Deserialize<Response>(jsonResponse);

    if (!string.IsNullOrEmpty(response.Error))
    {
        Console.WriteLine($"Error: {response.Error}");
    }
    else
    {
        Console.WriteLine(response.Result);
    }

    if (method.ToLower() == "stop")
    {
        socket.Close();
    }
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