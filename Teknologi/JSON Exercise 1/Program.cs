
using JSON_Exercise_1.Models;
using System.Text.Json;

string? brand;
string? model;
string? color;
int mileage;

Console.Write("Type car brand: ");
brand = Console.ReadLine();
Console.Write("Type car model: ");
model = Console.ReadLine();
Console.Write("Type car color: ");
color = Console.ReadLine();
Console.Write("Type car mileage: ");
if (!int.TryParse(Console.ReadLine(), out mileage))
{
    if (mileage < 0)
    {
        mileage = -1;
    }
}

Car newCar = new Car(brand, model, color, mileage);
Console.WriteLine("\nThis is your new car:");
Console.WriteLine(newCar);

Console.WriteLine();

string jsonExpected = $$"""{"Brand":"{{newCar.Brand}}","Model":"{{newCar.Model}}","Color":"{{newCar.Color}}","Mileage":{{newCar.Mileage}}}""";
string jsonCar = JsonSerializer.Serialize(newCar);

Console.Write(jsonExpected);
Console.WriteLine(" - Expected JSON string");
Console.Write(jsonCar);
Console.WriteLine(" - Actual JSON string");
