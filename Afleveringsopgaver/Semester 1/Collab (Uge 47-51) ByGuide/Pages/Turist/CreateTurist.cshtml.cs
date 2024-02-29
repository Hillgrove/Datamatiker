using ByGuide.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ByGuide.Pages.Tursit
{
	public class CreateTuristModel : PageModel
	{
		#region Instance Fields
		private ITuristService _turistService;
		#endregion

		#region Constructor
		public CreateTuristModel(ITuristService turistService)
		{
			_turistService = turistService;
		}
		#endregion

		#region Properties
		[BindProperty]
		public Models.Turist Turist { get; set; }
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

			_turistService.AddTurist(Turist);
			return RedirectToPage("GetAllTurists");
		}
		#endregion
	}
}