using IMDBInsertApproaches;

string filepath = @"C:\Programming\IMDBData\title.basics.tsv";
int linesToRead = 500000;

var titles = TSVReader.ReadFromFile(filepath, linesToRead);

for (int i = 0; i < 20; i++)
{
    Console.WriteLine(titles[i]);
}