namespace Calendar.Models;

public class CalendarEvent
{
    public int EventId { get; set; }

    public string? Name { get; set; }

    public string? Location { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string? Description { get; set; }

}