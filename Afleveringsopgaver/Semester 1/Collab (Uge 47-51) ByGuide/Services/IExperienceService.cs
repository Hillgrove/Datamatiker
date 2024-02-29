
// By: Jesper Højlund

using ByGuide.Models;

namespace ByGuide.Service
{
    public interface IExperienceService
    {
        #region Methods
        void AddExperience(Experience experience);
        Experience GetExperience(int id);
        List<Experience> GetExperiences();
        IEnumerable<Experience> Search(string str);
        IEnumerable<Experience> Filter(int maxPrice, int minPrice = 0, string? category = null);
        void UpdateExperience(Experience experience);
        Experience DeleteExperience(int? id);
        #endregion
    }
}
