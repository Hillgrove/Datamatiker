using ByGuide.Helpers;
using ByGuide.MockData;
using ByGuide.Models;
using ByGuide.Services;

namespace ByGuide.Service
{
	public class EventService : IEventService
    {
        #region Instance Fields
        private List<Event> _events;
        #endregion

        #region Constructor
        public EventService(JsonFileEventService jsonFileEventService)
        {
            JsonFileEventService = jsonFileEventService;
            _events = JsonFileEventService.GetJsonEvents().ToList();
        }
        #endregion

        #region Properties
        private JsonFileEventService JsonFileEventService { get; set; }
        #endregion

        #region Methods
        public void AddEvent(Event events)
        {          
            _events.Add(events);
            JsonFileEventService.SaveJsonEvent(_events);
        }

        public Event GetEvents(string name)
        {
            foreach (Event events in _events)
            {
                if (events.Name == name)
                {
                    return events;
                }
            }

            return null;
        }

        public List<Event> GetEvents()
        {
            return _events;
        }

        public IEnumerable<Event> EventSearch(string name)
        {
            List<Event> searchResults = new List<Event>();
            foreach (Event events in _events)
            {
                if (string.IsNullOrEmpty(name) ||
                    events.Name.ToLower().Contains(name.ToLower()) ||
                    events.Name.ToLower().Contains(name.ToLower()))
                {
                    searchResults.Add(events);
                }
            }

            return searchResults;
        }

        public IEnumerable<Event> Filter(int MaxPrice, int minPrice = 0, string? category = null)
        {
            List<Event> filterList = new List<Event>();
            foreach (Event events in _events)
            {
                bool priceCondition = (minPrice == 0 && events.Price <= MaxPrice) ||
                    (MaxPrice == 0 && events.Price >= minPrice) ||
                    (events.Price >= minPrice && events.Price <= MaxPrice);
                             
            }

            return filterList;
        }

        public void UpdateEvents(Event events)
        {
            if (events != null)
            {
                foreach (Event e in _events)
                {
                    if (e.Name == events.Name)
                    {
                        e.Price = events.Price;
                        e.DatetimeList = events.DatetimeList;                                                                   
                        e.ExternalLink = events.ExternalLink;
                        e.HandicapAccessible = events.HandicapAccessible;
                    }
                }

                JsonFileEventService.SaveJsonEvent(_events);
            }
        }

        public Event DeleteEvent(string name)
        {
            Event? eventsToBeDeleted = null;
            foreach (Event events in _events)
            {
                if (events.Name == name)
                {
                    eventsToBeDeleted = events;
                    break;
                }
            }

            if (eventsToBeDeleted != null)
            {
                _events.Remove(eventsToBeDeleted);
                JsonFileEventService.SaveJsonEvent(_events);
            }

            return eventsToBeDeleted;
        }

        #endregion
    }
}
