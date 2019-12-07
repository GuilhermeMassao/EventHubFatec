using EventHub.Domain.DTOs.Event;
using EventHub.Domain.Entities;
using System.Threading.Tasks;

namespace EventHub.Infrastructure.Interfaces.Repository
{
    public interface IEventRepository
    {
        Task<int?> CreateEvent(Event entity);
        Task<int?> UpdateEvent(int id, Event entity);
        Task<EventDto> GetById(int id);
    }
}
