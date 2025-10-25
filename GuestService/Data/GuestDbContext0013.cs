using Microsoft.EntityFrameworkCore;
using GuestService.Models;

namespace GuestService.Data
{
    public class GuestDbContext0013 : DbContext
    {
        public GuestDbContext0013(DbContextOptions<GuestDbContext0013> options) 
            : base(options) 
        { 
        }

        public DbSet<Guest0013> Guests { get; set; }
    }
}