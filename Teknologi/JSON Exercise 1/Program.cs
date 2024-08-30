
using JSON_Exercise_1.Models;
using System.Text.Json;


// Part 1
Car carA = new Car("Opel", "Kadet", "Red", 10000);
Console.WriteLine(carA);

// Part 2
string expectedCarSerialization = """{"Brand":"Opel","Model":"Kadet","Color":"Red","Mileage":10000}""";
string serializedCar = JsonSerializer.Serialize(carA);

Console.WriteLine(expectedCarSerialization);
Console.WriteLine(serializedCar);

Car carB = new Car();
List<Car> carList = new List<Car>  { carA, carB };

string expectectListSerialization = """[{"Brand":"Opel","Model":"Kadet","Color":"Red","Mileage":10000},{"Brand":null,"Model":null,"Color":null,"Mileage":0}]""";
string serializedList =  JsonSerializer.Serialize(carList);

Console.WriteLine(expectectListSerialization);
Console.WriteLine(serializedList);

// Part 3