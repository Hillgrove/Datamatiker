using ImdbDataInsert;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;

string filepath = @"C:\Programming\IMDBData\title.basics.tsv";
int linesToRead = 50000;
var titles = TSVReader.ReadFromFile(filepath, linesToRead);

Stopwatch stopwatch = new Stopwatch();

using SqlConnection sqlConn = new(
    "Server=Hilldesk;" +
    "Database=ImdbBasics;" +
    "Integrated Security=True;" +
    "TrustServerCertificate=True;");

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
            Inserter(new NormalInserter());
            break;
        case "p":
            Inserter(new PreparedInserter());
            break;
        case "e":
            Inserter(new EfCoreInserter());
            break;
        case "b":
            break;
        case "q":
            Console.WriteLine("\nThanks for using the magical wonderland... Stay safe");
            return;
    }
}

void PrintMenu()
{
    Console.WriteLine("Welcome to the magical wonderland of SQL insertions.\n");
    Console.WriteLine("Please let me know what action you want to take:");
    Console.WriteLine("Normal Insertion:\t\t(n)");
    Console.WriteLine("Prepared Insertion:\t\t(p)");
    Console.WriteLine("Entity FrameWork insertion:\t(e)");
    Console.WriteLine("Bulk Insert: \t\t\t(b)");
    Console.WriteLine("Quit: \t\t\t\t(q)");
    Console.WriteLine();
}

void Inserter(IInserter inserter)
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
