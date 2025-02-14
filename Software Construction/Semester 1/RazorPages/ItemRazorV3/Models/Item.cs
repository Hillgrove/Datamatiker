using System.ComponentModel.DataAnnotations;

namespace ItemRazorV1.Models
{
    public class Item
    {
        public Item()
        {
        }

        public Item(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        [Display(Name = "Item ID")]
        [Required(ErrorMessage = "Der skal angives et ID til Item")]
		[Range(typeof(int), "0", "10000", ErrorMessage = "ID skal være mellem (1) og (2)")]
		public int? Id { get; set; }

        [Display(Name = "Item navn")]
        [Required(ErrorMessage = "Item skal have et navn")]
        public string? Name { get; set; }

        [Display(Name = "Pris")]
        [Required(ErrorMessage = "Der skal angives en pris")]
        public double? Price { get; set; }

    }
}
