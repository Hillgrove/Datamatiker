
// By: Jesper Højlund

using System.ComponentModel.DataAnnotations;

namespace ByGuide.Models
{
    public class Experience : IContent
    {
        #region Constructors
        public Experience()
        {
        }

        public Experience(int id, string? title, string? description, string? category, int admissionPrice, string? address, string? externalLink, bool handicapAccesible, string? imageURL, Dictionary<string, string>? openingHours)
        {
            Id = id;
            Title = title;
            Description = description;
            Category = category;
            AdmissionPrice = admissionPrice;
            Address = address;
            ExternalLink = externalLink;
            HandicapAccesible = handicapAccesible;
            ImageURL = imageURL;
            OpeningHours = openingHours;
        }
        #endregion

        #region Properties
        [Display(Name = "Oplevelses Id")]
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

        [Display(Name = "Pris")]
        public int AdmissionPrice { get; set; }

        [Display(Name = "Adresse")]
        [Required(ErrorMessage = "Angiv venligst en adresse eller lokation")]
        public string? Address { get; set; }

        [Display(Name = "Link til oplevelsen")]
        [Required(ErrorMessage = "Angiv venligst et link til hvor man kan læse mere om oplevelsen")]
        public string? ExternalLink { get; set; }

        [Display(Name = "Er stedet handicapvenligt")]
        public bool HandicapAccesible { get; set; }

        [Display(Name = "Billed URL")]
        public string? ImageURL { get; set; }

        [Display(Name = "Åbningstider")]
        public Dictionary<string, string>? OpeningHours { get; set; }
        #endregion
    }
}
