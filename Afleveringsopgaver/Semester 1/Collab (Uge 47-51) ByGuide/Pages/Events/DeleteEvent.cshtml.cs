using ByGuide.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ByGuide.Pages.Events
{
	public class DeleteEventModel : PageModel
	{
		#region Instance Fields
		private IEventService _eventService;
		#endregion

		#region Constructor
		public DeleteEventModel(IEventService eventService)
		{
			_eventService = eventService;
		}
		#endregion

		#region Properties
		[BindProperty]
		public Models.Event Event { get; set; }
		#endregion

		#region Methods
		public IActionResult OnGet(string name)
		{
			Event = _eventService.GetEvents(name);
			if (Event == null)
			{
				return RedirectToPage("/NotFound");
			}

			return Page();
		}

		public IActionResult OnPost()
		{
			Models.Event deletedEvent = _eventService.DeleteEvent(Event.Name);
			if (deletedEvent == null)
			{
				return RedirectToPage("/NotFound");
			}

			return RedirectToPage("GetAllEvents");
		}
		#endregion
	}
}