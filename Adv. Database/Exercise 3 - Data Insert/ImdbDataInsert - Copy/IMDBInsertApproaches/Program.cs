using IMDBInsertApproaches;

string filepath = @"C:\Programming\IMDBData\title.basics.tsv";
int linesToRead = 50000;

DateTime startTime = DateTime.Now;
var titles = TSVReader.ReadFromFile(filepath, linesToRead);
Console.WriteLine();

NormalInserter.InsertData(titles);
DateTime endTime = DateTime.Now;

double seconds = endTime.Subtract(startTime).TotalSeconds;
Console.WriteLine($"Inserting {linesToRead} records using Normal Insert takes {seconds:F2} seconds");
Console.WriteLine($"Inserting 11.000.000 records would take an estimated time of {11000000 / linesToRead * seconds:F2} seconds");