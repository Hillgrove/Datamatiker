
using System.Text.Json;
using JSON_Exercise_1.Models;


namespace JSON_Exercise_1.Solutions
{
    public class JsonStringSerialization
    {
        private string? _brand;
        private string? _model;
        private string? _color;
        private int _mileage;

        public void Run()
        {
            Console.Write("Type car brand: ");
            _brand = Console.ReadLine();
            Console.Write("Type car model: ");
            _model = Console.ReadLine();
            Console.Write("Type car color: ");
            _color = Console.ReadLine();
            Console.Write("Type car mileage: ");
            if (!int.TryParse(Console.ReadLine(), out _mileage))
            {
                if (_mileage < 0)
                {
                    _mileage = -1;
                }
            }

            Car newCar = new Car(_brand, _model, _color, _mileage);
            Console.WriteLine("\nThis is your new car:");
            Console.WriteLine(newCar);

            Console.WriteLine();

            string jsonExpected = $$"""{"Brand":"{{newCar.Brand}}","Model":"{{newCar.Model}}","Color":"{{newCar.Color}}","Mileage":{{newCar.Mileage}}}""";
            string jsonCar = JsonSerializer.Serialize(newCar);

            Console.Write(jsonExpected);
            Console.WriteLine(" - Expected JSON string");
            Console.Write(jsonCar);
            Console.WriteLine(" - Actual JSON string");

        }
    }
}