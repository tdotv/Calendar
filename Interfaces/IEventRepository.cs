using Calendar.Models;

namespace Calendar.Interfaces
{
    public interface IEventRepository
    {
        Task<IEnumerable<CalendarEvent>> GetAllEvents();
        Task<IEnumerable<CalendarEvent>> GetAllEventsNoTracking();
        Task<CalendarEvent> GetEventById(string id);
        bool Add(CalendarEvent calendarEvent);
        bool Edit(CalendarEvent calendarEvent);
        bool Delete(CalendarEvent calendarEvent);
        bool Save();
    }
}