namespace EventHub.Domain.Entities
{
    public class EventSubscribers
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
    }
}
