using Microsoft.EntityFrameworkCore;
using Calendar.Data;
using Calendar.Interfaces;
using Calendar.Models;

namespace Calendar.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _context;
        public EventRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(CalendarEvent calendarEvent)
        {
            _context.Add(calendarEvent);
            return Save();
        }

        public bool Edit(CalendarEvent calendarEvent)
        {
            _context.Update(calendarEvent);
            return Save();
        }

        public bool Delete(CalendarEvent calendarEvent)
        {
            _context.Remove(calendarEvent);
            return Save();
        }

        public async Task<IEnumerable<CalendarEvent>> GetAllEvents() => await _context.CalendarEvent.ToListAsync();

        public async Task<IEnumerable<CalendarEvent>> GetAllEventsNoTracking() =>  await _context.CalendarEvent.AsNoTracking().ToListAsync();

        public async Task<CalendarEvent> GetEventById(string id) => await _context.CalendarEvent.FindAsync(id) ?? throw new NullReferenceException();

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}