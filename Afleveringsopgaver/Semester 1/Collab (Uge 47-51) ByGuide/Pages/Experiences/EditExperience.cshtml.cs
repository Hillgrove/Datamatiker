
// By: Jesper Højlund

using ByGuide.Helpers;
using ByGuide.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ByGuide.Pages.Experiences
{
    public class EditExperienceModel : PageModel
    {
        #region Instance Fields
        private IExperienceService _experienceService;
        #endregion

        #region Constructor
        public EditExperienceModel(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }
        #endregion

        #region Properties
        [BindProperty]
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

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Converts the form data to a dictionary
            Experience.OpeningHours = OpeningHoursHelper.ParseFromForm(Request.Form); ;

            _experienceService.UpdateExperience(Experience);
            return RedirectToPage("GetAllExperiences");
        }
        #endregion
    }
}
