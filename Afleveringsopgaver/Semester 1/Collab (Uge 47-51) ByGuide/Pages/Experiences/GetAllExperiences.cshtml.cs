
// By: Jesper Højlund

using ByGuide.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ByGuide.Pages.Experiences
{
    public class GetAllExperiencesModel : PageModel
    {
        #region Instance Fields
        private IExperienceService _experienceService;
        #endregion

        #region Constructor
        public GetAllExperiencesModel(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }
        #endregion

        #region Properties
        public List<Models.Experience>? Experiences { get; private set; }

        [BindProperty]
        public string SearchString { get; set; }

        [BindProperty]
        public int MinPrice { get; set; }

        [BindProperty]
        public int MaxPrice { get; set; }

        [BindProperty]
        public string Category { get; set; }
        #endregion

        #region Methods
        public void OnGet()
        {
            Experiences = _experienceService.GetExperiences();
        }

        public IActionResult OnPostSearch()
        {
            Experiences = _experienceService.Search(SearchString).ToList();
            return Page();
        }

        public IActionResult OnPostFilter()
        {
            Experiences = _experienceService.Filter(MaxPrice, MinPrice, Category).ToList();
            return Page();
        }
        #endregion
    }
}