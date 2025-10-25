using System.ComponentModel.DataAnnotations;

namespace EventService.Models
{
    public class Event0013
    {
        [Key]
        public int EventId { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Venue { get; set; } = string.Empty;
    }
}