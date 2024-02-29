
// By: Jesper Højlund

namespace ByGuide.Models
{
    public interface IContent
    {
        int? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? ImageURL { get; set; }
    }
}
