using ByGuide.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ByGuide.Pages.Tursit
{
	public class EditTuristModel : PageModel
	{
	  
			#region Instance Fields
			private ITuristService _turistService;
		#endregion

		#region Constructor
		public EditTuristModel(ITuristService turistService)
		{
			_turistService = turistService;
		}
		#endregion

		#region Properties
		[BindProperty]
		public Models.Turist Turist { get; set; }
		#endregion

		#region Methods
		public IActionResult OnGet(int id)
		{
			Turist = _turistService.GetTurist(id);
			if (Turist == null)
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

			_turistService.UpdateTurist(Turist);
			return RedirectToPage("GetAllTurists");
		}
	     	#endregion
    }
}