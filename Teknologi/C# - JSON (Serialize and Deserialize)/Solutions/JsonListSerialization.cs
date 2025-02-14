
using System.Text.Json;
using JSON_Exercise_1.Models;

namespace JSON_Exercise_1.Solutions
{
    public class JsonListSerialization
    {
        private string? _brand;
        private string? _model;
        private string? _color;
        private int _mileage;
        private List<Car> _cars = new();

        public void Run()
        {
            bool addingAnotherCar = true;
            do
            {
                Console.Write("Type car brand: ");
                _brand = Console.ReadLine();
                Console.Write("Type car model: ");
                _model = Console.ReadLine();
                Console.Write("Type car color: ");
                _color = Console.ReadLine();
                Console.Write("Type car mileage: ");
                if (!int.TryParse(Console.ReadLine(), out _mileage) || _mileage < 0)
                {
                    _mileage = -1;
                }

                _cars.Add(new Car(_brand, _model, _color, _mileage));

                Console.Write("\nDo you want to add another car (y/n): ");
                string answer = Console.ReadLine()!;
                if (answer == "n")
                {
                    addingAnotherCar = false;
                }

                Console.WriteLine();

            } while (addingAnotherCar);

            string jsonExpected = "[" +
                string.Join(",", _cars.Select(car =>
                    $$"""{"Brand":"{{car.Brand}}","Model":"{{car.Model}}","Color":"{{car.Color}}","Mileage":{{car.Mileage}}}"""
                ))
                + "]";

            string jsonCarList = JsonSerializer.Serialize(_cars);

            Console.Write(jsonExpected);
            Console.WriteLine(" - Expected JSON string");
            Console.Write(jsonCarList);
            Console.WriteLine(" - Actual JSON string");
        }
    }
}
