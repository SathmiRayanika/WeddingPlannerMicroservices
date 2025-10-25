using System.ComponentModel.DataAnnotations;

namespace GuestService.Models
{
    public class Guest0013
    {
        [Key]
        public int GuestId { get; set; }
        public int EventId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string RSVP { get; set; } = "Pending"; // Yes/No/Pending
    }
}