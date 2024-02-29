using ByGuide.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ByGuide.Pages.Events
{
    public class GetEventsModel : PageModel
    {
        #region Instance Fields
        private IEventService _eventService;
        #endregion

        #region Constructor
        public GetEventsModel(IEventService eventService)
        {
            _eventService = eventService;
        }
        #endregion

        #region Properties
        public Models.Event? Event { get; private set; }

        [BindProperty(SupportsGet = true)]
        public string EventName { get; set; }
        #endregion

        #region Methods
        public IActionResult OnGet(string name)
        {
            EventName = EventName;
            Event = _eventService.GetEvents(EventName);

            if (Event == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }
        #endregion
    }
}
