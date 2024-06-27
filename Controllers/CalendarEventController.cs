using Microsoft.AspNetCore.Mvc;
using Calendar.Interfaces;
using Calendar.Models;
using Calendar.ViewModels;
using Calendar.Data;
using System.Data.Entity;

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

        public async Task<IActionResult> Index()
        {
            var myEntities = await _context.CalendarEvent.ToListAsync();
            return View(myEntities);
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
                // TempData["success"] = "Car created successfully";
                return RedirectToAction("Index");
            }
            else
                ModelState.AddModelError("", "Can't create new car");
            return View(eventViewModel);
        }
    }
}