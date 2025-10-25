using Microsoft.EntityFrameworkCore;
using EventService.Models;

namespace EventService.Data
{
    public class EventDbContext0013 : DbContext
    {
        public EventDbContext0013(DbContextOptions<EventDbContext0013> options)
            : base(options) { }

        public DbSet<Event0013> Events { get; set; }
    }
}