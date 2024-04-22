using System.ComponentModel.DataAnnotations;

namespace WebShopRPV0.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A name is required")]
        public string Name { get; set; }
        [Range(0, 99999.99, ErrorMessage = "Price needs to be between 0 and 100.000")]
        public double Price { get; set; }

        public Product() { }
        public Product(string name, double price)
        {
            Id = 0;
            Name = name;
            Price = price;
        }

        public void Update(Product other)
        {
            Name = other.Name;
            Price = other.Price;
        }
    }
}
