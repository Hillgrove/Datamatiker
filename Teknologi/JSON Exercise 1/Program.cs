
using JSON_Exercise_1.Models;
using System.Text.Json;


// Part 1
Car carA = new Car("Opel", "Kadet", "Red", 10000);
Console.WriteLine("Part 1:");
Console.WriteLine(carA);

// Part 2 - Serialization
string expectedCarSerialization = """{"Brand":"Opel","Model":"Kadet","Color":"Red","Mileage":10000}""";
string serializedCar = JsonSerializer.Serialize(carA);

Console.WriteLine("\nPart 2:");
Console.WriteLine("Expected serialization:");
Console.WriteLine(expectedCarSerialization);
Console.WriteLine("Actual serialization:");
Console.WriteLine(serializedCar);

Car carB = new Car();
List<Car> carList = new List<Car>  { carA, carB };

string expectectListSerialization = """[{"Brand":"Opel","Model":"Kadet","Color":"Red","Mileage":10000},{"Brand":null,"Model":null,"Color":null,"Mileage":0}]""";
string serializedList =  JsonSerializer.Serialize(carList);

Console.WriteLine("\nExpected list-serialization:");
Console.WriteLine(expectectListSerialization);
Console.WriteLine("Actual list-serialization:");
Console.WriteLine(serializedList);

// Part 3 - Deserialization
Car? deserialzedCard = JsonSerializer.Deserialize<Car>(serializedCar);
Console.WriteLine("\nPart 3:");
Console.WriteLine("Deserialized car:");
Console.WriteLine(deserialzedCard);

List<Car>? deserializedCars = JsonSerializer.Deserialize<List<Car>>(serializedList);
Console.WriteLine("\nDeserialized list of cars:");
if (deserializedCars != null)
{
    foreach (Car car in deserializedCars)
    {
        Console.WriteLine(car);
    }
}
else
{
    Console.WriteLine("Deserialization failed or list is empty");
}

// Part 4 - Special Characters
string manualCarSerialization = """{"Brand":"Opel","Model":"The \"Old\" Car","Color":"Red","Mileage":10000}""";
Car carC = JsonSerializer.Deserialize<Car>(manualCarSerialization)!;
Console.WriteLine("\nPart 4:");
Console.WriteLine(carC);

// Part 5 - Extra
string jsonDealership = "{\"Name\":\"Move Cars\",\"Address\":\"MagleGaardsvej 2\",\"Cars\":[{\"Brand\":\"BMW\",\"Model\":\"330e\",\"Color\":\"Green\",\"Mileage\":45721},{\"Brand\":\"VW\",\"Model\":\"Golf\",\"Color\":\"Red\",\"Mileage\":20},{\"Brand\":\"Ford\",\"Model\":\"Galaxy\",\"Color\":\"Black\",\"Mileage\":124326}],\"Employees\":[{\"Name\":\"Move\",\"Salary\":1000000,\"MonthsEmployed\":28,\"JobAreas\":[\"President\",\"Mechanic\"]},{\"Name\":\"Not Move\",\"Salary\":100,\"MonthsEmployed\":13,\"JobAreas\":[\"Vice-President\",\"Mechanic\"]}]}";
Dealership dealership = JsonSerializer.Deserialize<Dealership>(jsonDealership);

Console.WriteLine("\nPart 5:");
Console.WriteLine(dealership);