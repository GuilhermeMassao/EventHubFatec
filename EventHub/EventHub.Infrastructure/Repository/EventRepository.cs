using EventHub.Domain;
using EventHub.Infraestructure.Repository.BaseRepository;
using EventHub.Infrastructure.Interfaces.Repository;

namespace EventHub.Infrastructure.Repository
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(EventHubEntities context) : base(context)
        {
        }
    }
}
