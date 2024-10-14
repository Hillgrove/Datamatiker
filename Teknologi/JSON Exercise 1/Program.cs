
using JSON_Exercise_1.Models;

Car carSis = new Car(brand: "Peugeot", model: "206", color: "Black");
Console.WriteLine(carSis);

string? brand;
string? model;
string? color;
int mileage;

Console.Write("\nType car brand: ");
brand = Console.ReadLine();
Console.Write("Type car model: ");
model = Console.ReadLine();
Console.Write("Type car color: ");
color = Console.ReadLine();
Console.Write("Type car mileage: ");
if (!int.TryParse(Console.ReadLine(), out mileage))
{
    mileage = -1;
}

Car newCar = new Car(brand, model, color, mileage);
Console.WriteLine("\nThis is your new car:");
Console.WriteLine(newCar);