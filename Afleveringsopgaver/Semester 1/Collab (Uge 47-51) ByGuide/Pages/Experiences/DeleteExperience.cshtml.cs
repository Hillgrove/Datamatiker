
// By: Jesper Højlund

using ByGuide.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ByGuide.Pages.Experiences
{
    public class DeleteExperienceModel : PageModel
    {
        #region Instance Fields
        private IExperienceService _experienceService;
        #endregion

        #region Constructor
        public DeleteExperienceModel(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }
        #endregion

        #region Properties
        public Models.Experience Experience { get; set; }
        #endregion

        #region Methods
        public IActionResult OnGet(int id)
        {
            Experience = _experienceService.GetExperience(id);
            if (Experience == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            Models.Experience deletedExperience = _experienceService.DeleteExperience(id);
            if (deletedExperience == null)
            {
                return RedirectToPage("/NotFound");
            }

            return RedirectToPage("GetAllExperiences");
        }
        #endregion
    }
}
