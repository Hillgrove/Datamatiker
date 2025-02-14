using System.ComponentModel.DataAnnotations;

namespace WebShopRPV0.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Der skal angives et navn")]
        public string Name { get; set; }
        [Range(0, 99999.99, ErrorMessage = "Pris skal være meellem 0 og 100.000")]
        public double Price { get; set; }

        public Product() { }
        public Product(string name, double price)
        {
            Id = 0;
            Name = name;
            Price = price;
        }
    }
}
