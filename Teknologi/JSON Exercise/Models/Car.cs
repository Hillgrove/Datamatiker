
namespace JSON_Exercise_1.Models
{
    public class Car
    {
        public string Brand { get; set; }
        public string  Model { get; set; }
        public string Color { get; set; }
        public int Mileage { get; set; }

        public Car()
        {
            Brand = "Undefined";
            Model = "Undefined";
            Color = "Undefined";
            Mileage = -1;
        }

        public Car(string? brand = null, string? model = null, string? color = null, int mileage = -1)
        {
            Brand = string.IsNullOrWhiteSpace(brand) ? "Undefined" : brand.Trim();
            Model = string.IsNullOrWhiteSpace(model) ? "Undefined" : model.Trim();
            Color = string.IsNullOrWhiteSpace(color) ? "Undefined" : color.Trim();

            Mileage = mileage;
        }

        public override string ToString()
        {
            return $"Brand: {Brand} - Model: {Model} - Color: {Color} - Mileage: {Mileage}";
        }
    }
}
