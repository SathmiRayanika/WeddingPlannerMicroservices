using Microsoft.EntityFrameworkCore;
using TaskService.Models;

namespace TaskService.Data
{
    public class TaskDbContext0013 : DbContext
    {
        public TaskDbContext0013(DbContextOptions<TaskDbContext0013> options)
            : base(options) { }

        public DbSet<WeddingTask0013> Tasks { get; set; }
    }
}