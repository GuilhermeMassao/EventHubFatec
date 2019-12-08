using EventHub.Domain.Entities.EntityBase;

namespace EventHub.Domain.Entities
{
    public class EventSubscribers : Entity
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
    }
}
