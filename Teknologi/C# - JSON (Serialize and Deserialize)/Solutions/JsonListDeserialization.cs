
using System.Text.Json;
using JSON_Exercise_1.Models;

namespace JSON_Exercise_1.Solutions
{
    internal class JsonListDeserialization
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

            List<Car> carsListA = new(_cars);
            string jsonCarsListA = JsonSerializer.Serialize(carsListA);
            List<Car>? carsListB = JsonSerializer.Deserialize<List<Car>>(jsonCarsListA);

            Console.WriteLine("carsListA:");
            foreach (Car car in carsListA)
            {
                Console.WriteLine(car);
            }

            Console.WriteLine();
            Console.WriteLine("carsListB:");
            foreach (Car car in carsListB)
            {
                Console.WriteLine(car);
            }
        }
    }
}
