
using System.Text.Json;
using JSON_Exercise_1.Models;

namespace JSON_Exercise_1.Solutions
{
    public class JsonStringDeserialization
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

            Car carA = new Car(_brand, _model, _color, _mileage);
            string jsonCarA = JsonSerializer.Serialize(carA);
            Car? carB = JsonSerializer.Deserialize<Car>(jsonCarA);

            Console.WriteLine();
            Console.WriteLine($"carA: {carA}");
            Console.WriteLine($"carB: {carB}");
        }
    }
}
