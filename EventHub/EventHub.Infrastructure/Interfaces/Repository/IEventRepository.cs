using EventHub.Domain.DTOs.Event;
using EventHub.Domain.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventHub.Infrastructure.Interfaces.Repository
{
    public interface IEventRepository
    {
        Task<int?> CreateEvent(Event entity);
        Task<bool> UpdateEvent(int id, Event entity);
        Task<CompleteEventDto> GetById(int id);
        Task<IEnumerable<EventDto>> GetEventsButUser(int id);
    }
}
