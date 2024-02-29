using ByGuide.Models;

namespace ByGuide.Service
{
	public interface IEventService

    {
        #region Methods
        void AddEvent(Event events);
        Event GetEvents(string name);
        List<Event> GetEvents();
        IEnumerable<Event> EventSearch(string name);
        IEnumerable<Event> Filter(int maxPrice, int minPrice = 0, string? category = null);
        void UpdateEvents(Event events);
        Event DeleteEvent(string name);
        #endregion
    }
}
