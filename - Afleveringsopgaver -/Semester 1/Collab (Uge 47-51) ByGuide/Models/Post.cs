
// By: Jesper Højlund

using System.ComponentModel.DataAnnotations;

namespace ByGuide.Models
{
	public class Post : IContent
	{
		#region Constructors
		public Post()
		{
		}

		public Post(int id, string title, string description, string category, string address, string? imageURL = null)
		{
            Id = id;
            Title = title;
			Description = description;
			Category = category;
			Address = address;
			ImageURL = imageURL;
		}
		#endregion

		#region Properties
		[Display(Name = "Post Id")]
		public int? Id { get; set; }

		[Display(Name = "Titel")]
		[Required(ErrorMessage = "Indlægget skal have en titel")]
		public string? Title { get; set; }

		[Display(Name = "Beskrivelse")]
		[Required(ErrorMessage = "Der skal være en beskrivelse")]
		public string? Description { get; set; }

		[Display(Name = "Kategori")]
		[Required(ErrorMessage = "Der skal angives en kategori")]
		public string? Category { get; set; }

		[Display(Name = "Adresse")]
		[Required(ErrorMessage = "Angiv venligst en adresse eller lokation")]
		public string? Address { get; set; }

		[Display(Name = "Billed URL")]
		public string? ImageURL { get; set; }
		#endregion
	}
}
