using ByGuide.Models;
using ByGuide.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ByGuide.Pages.Events
{
	public class GetAllEventsModel : PageModel
	{
		#region Instance Fields
		private IEventService _eventService;
		#endregion

		#region Constructor
		public GetAllEventsModel(IEventService eventService)
		{
			_eventService = eventService;
		}
		#endregion

		#region Properties
		public List<Models.Event>? Events { get; private set; }

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
			Events = _eventService.GetEvents();
		}

		public IActionResult OnEventSearch()
		{
			Events = _eventService.EventSearch(SearchString).ToList();
			return Page();
		}
		#endregion
	}
}