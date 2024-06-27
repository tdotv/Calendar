using Microsoft.AspNetCore.Mvc;
using Calendar.Interfaces;
using Calendar.Models;
using Calendar.ViewModels;
using Calendar.Data;

namespace Calendar.Controllers
{
    public class CalendarEventController : Controller
    {
        private readonly IEventRepository _eventRepository;
        private readonly ApplicationDbContext _context;

        public CalendarEventController(IEventRepository eventRepository, ApplicationDbContext context)
        {
            _eventRepository = eventRepository;
            _context = context;
        }

        private static readonly List<CalendarEvent> events =
        [
            new CalendarEvent
            {
                EventId = 1,
                Name = "Team Meeting",
                Location = "Conference Room A",
                StartDate = new DateTime(2024, 6, 27, 10, 0, 0),
                EndDate = new DateTime(2024, 6, 27, 11, 30, 0),
                Description = "Weekly team meeting to discuss project progress."
            },
            new CalendarEvent
            {
                EventId = 2,
                Name = "Client Presentation",
                Location = "Virtual Meeting",
                StartDate = new DateTime(2024, 6, 27, 14, 0, 0),
                EndDate = new DateTime(2024, 6, 27, 15, 30, 0),
                Description = "Present project update to client."
            }
        ];

        public IActionResult Index()
        {
            return View(events);

            // var myEntities = await _context.CalendarEvent.ToListAsync();
            // return View(myEntities);
        }

        public IActionResult Details(int id)
        {
            var @event = events.FirstOrDefault(e => e.EventId == id);

            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        [HttpGet]
        public IActionResult Create() => View("Create");

        [HttpPost]
        public IActionResult Create(CreateEventViewModel eventViewModel)
        {
            if (ModelState.IsValid)
            {
                var calendarEvent = new CalendarEvent
                {
                    EventId = eventViewModel.EventId,
                    Name = eventViewModel.Name,
                    Location = eventViewModel.Location,
                    StartDate = eventViewModel.StartDate,
                    EndDate = eventViewModel.EndDate,
                    Description = eventViewModel.Description,
                };
                _eventRepository.Add(calendarEvent);
                TempData["success"] = "Event created successfully";
                return RedirectToAction("Index");
            }
            else
                ModelState.AddModelError("", "Can't create new event");
            return View(eventViewModel);
        }
    }
}