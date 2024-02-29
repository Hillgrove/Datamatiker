using ByGuide.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ByGuide.Pages.Events
{
    public class CreateEventModel : PageModel
	{
       
        #region Instance Fields
        private IEventService _eventService;
		#endregion

		#region Constructor
		public CreateEventModel(IEventService eventService)
		{
			_eventService = eventService;
		}
		#endregion

		#region Properties
		[BindProperty]
		public Models.Event Event { get; set; }
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

			_eventService.AddEvent(Event);
			return RedirectToPage("GetAllEvents");
		}
		#endregion
	}
}
    

