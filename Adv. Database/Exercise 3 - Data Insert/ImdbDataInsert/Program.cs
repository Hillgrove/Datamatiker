using ImdbDataInsert;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;

string filepath = @"C:\Programming\IMDBData\title.basics.tsv";
int linesToRead = 50000;
var titles = TSVReader.ReadFromFile(filepath, linesToRead);

double? normalSpeed = null;
double? preparedSpeed = null;
double? efCoreSpeed = null;
double? bulkSpeed = null;

Stopwatch stopwatch = new Stopwatch();

using SqlConnection sqlConn = new(
    "Server=Hilldesk;" +
    "Database=ImdbBasics;" +
    "Integrated Security=True;" +
    "TrustServerCertificate=True;");

// Main loop
while (true)
{
    Console.Clear();
    PrintMenu();

    Console.Write("Please enter action: ");
    string? choice = Console.ReadLine()?.Trim().ToLower();
    Console.WriteLine();

    switch (choice)
    {
        case "n":
            normalSpeed = Inserter(new NormalInserter());
            break;
        case "p":
            preparedSpeed = Inserter(new PreparedInserter());
            break;
        case "e":
            efCoreSpeed = Inserter(new EfCoreInserter());
            break;
        case "b":
            bulkSpeed = Inserter(new BulkInserter());
            break;
        case "q":
            Console.WriteLine("\nThanks for using the Magical SQL Inserter... Stay safe");
            return;
    }
}

void PrintMenu()
{
    Console.WriteLine();
    Console.WriteLine("===========================================");
    Console.WriteLine("   Welcome to the Magical SQL Inserter     ");
    Console.WriteLine("===========================================");
    Console.WriteLine();

    Console.WriteLine($"  [N] Normal Insertion       {FormatSpeed(normalSpeed, 20)}");
    Console.WriteLine($"  [P] Prepared Insertion     {FormatSpeed(preparedSpeed, 20)}");
    Console.WriteLine($"  [E] Entity Framework Insert{FormatSpeed(efCoreSpeed, 20)}");
    Console.WriteLine($"  [B] Bulk Insert            {FormatSpeed(bulkSpeed, 20)}");
    Console.WriteLine($"  [Q] Quit");

    Console.WriteLine("\n===========================================");
    Console.Write("Please enter action: ");
}

double Inserter(IInserter inserter)
{
    PrepareDatabase(sqlConn);

    var stopwatch = Stopwatch.StartNew();
    inserter.InsertData(sqlConn, titles);
    stopwatch.Stop();

    double seconds = stopwatch.Elapsed.TotalSeconds;
    Console.WriteLine();
    Console.WriteLine($"Inserting {linesToRead} records using {inserter.GetType().Name} took {seconds:F2} seconds");
    Console.WriteLine($"Inserting 11.000.000 records would take an estimated time of {11000000 / linesToRead * seconds:F2} seconds");

    Console.Write("\nPress enter to return to menu");
    Console.ReadKey();

    return seconds;
}

void PrepareDatabase(SqlConnection sqlConn)
{
    Console.WriteLine("\nPreparing database for testing...");
    int deletedRows = RemoveRowsFromDB();
    Console.WriteLine($"{deletedRows} rows deleted from database");
}

int RemoveRowsFromDB()
{
    try
    {
        // If connection from program.cs has idled out
        if (sqlConn.State == ConnectionState.Closed)
            sqlConn.Open();
        using SqlCommand cmd = new("DELETE FROM Title", sqlConn);
        return cmd.ExecuteNonQuery();
    }
    catch (SqlException ex)
    {
        Console.WriteLine($"Database error: {ex.Message}");
        return - 1;
    }
}

string FormatSpeed(double? speed, int width)
{
    return speed != null ? $"[{speed:F2}s]".PadLeft(width) : "[Not run]".PadLeft(width);
}