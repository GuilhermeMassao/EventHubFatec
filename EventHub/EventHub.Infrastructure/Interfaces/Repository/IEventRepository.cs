using EventHub.Domain;
using EventHub.Infraestructure.Interfaces.Repository;

namespace EventHub.Infrastructure.Interfaces.Repository
{
    interface IEventRepository : IRepository<Event>
    {
    }
}
