
// By: Jesper Højlund

using ByGuide.Helpers;
using ByGuide.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ByGuide.Pages.Experiences
{
    public class CreateExperienceModel : PageModel
    {
        #region Instance Fields
        private IExperienceService _experienceService;
        #endregion

        #region Constructor
        public CreateExperienceModel(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }
        #endregion

        #region Properties
        [BindProperty]
        public Models.Experience Experience { get; set; }
        #endregion

        #region Methods
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Converts the form data to a dictionary
            Experience.OpeningHours = OpeningHoursHelper.ParseFromForm(Request.Form);

            _experienceService.AddExperience(Experience);
            return RedirectToPage("GetAllExperiences");
        }
        #endregion
    }
}
