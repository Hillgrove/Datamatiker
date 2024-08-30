
namespace JSON_Exercise_1.Models
{
    internal class Car
    {
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? Color { get; set; }
        public int Mileage { get; set; }

        public Car()
        {
        }
        
        
        public Car(string brand, string model, string color, int mileage)
        {
            Brand = brand;
            Model = model;
            Color = color;
            Mileage = mileage;
        }

        public override string ToString()
        {
            //“Brand: BMW - Model: 330e - Color: Green - Mileage: 45721”
            return $"Brand: {Brand} - Model: {Model} - Color: {Color} - Mileage: {Mileage}";
        }


    }
}
