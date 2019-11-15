using EventHub.Domain;
using EventHub.Domain.Entities;
using EventHub.Infraestructure.Repository.BaseRepository;
using EventHub.Infrastructure.Interfaces.Repository;
using System.Data.Entity;

namespace EventHub.Infrastructure.Repository
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
    }
}
