using System.ComponentModel.DataAnnotations;

namespace ByGuide.Models
{
	public class Turist
	{

		public Turist()
		{
		}

		public Turist(int id, string name, string email, string address)
		{
			Id = id;
			Name = name;
			Email = email;
			Address = address;
		}
		[Display(Name = "Turist ID")]
		[Required(ErrorMessage = "IT should gives ID to Turist")]
		[Range(typeof(int), "0", "10000", ErrorMessage = "ID Number should be between (1) and (2)")]
		public int? Id { get; set; }

		[Display(Name = "Turist Name")]
		[Required(ErrorMessage = "Tursit should have a name")]
		public string? Name { get; set; }

		[Display(Name = "Turist E-mail")]
		[Required(ErrorMessage = "Tursit should have an e-mail adresse")]
		[EmailAddress(ErrorMessage = "accessible e-mail adresse")]
		public string? Email { get; set; }

		[Display(Name = "Tursit Adresse")]
		[Required(ErrorMessage = "Tursit Should have an adresse")]
		public string? Address { get; set; }
	}
}
