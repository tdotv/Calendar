using Microsoft.EntityFrameworkCore;
using Calendar.Models;

namespace Calendar.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> User { get; set; }
    public DbSet<CalendarEvent> CalendarEvent { get; set; }
}