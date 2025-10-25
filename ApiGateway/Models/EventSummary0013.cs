namespace ApiGateway.Models
{
    public class EventSummary0013
    {
        public Event0013? Event { get; set; }
        public List<Guest0013> Guests { get; set; } = new();
        public List<TaskItem0013> Tasks { get; set; } = new();
    }
}