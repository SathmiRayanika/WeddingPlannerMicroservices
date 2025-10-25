using System.ComponentModel.DataAnnotations;

namespace TaskService.Models
{
    public class WeddingTask0013
    {
        [Key]
        public int TaskId { get; set; }
        public int EventId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending"; // Pending/Done
    }
}