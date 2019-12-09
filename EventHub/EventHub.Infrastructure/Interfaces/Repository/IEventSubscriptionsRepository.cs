using EventHub.Domain.DTOs.Event;
using EventHub.Domain.DTOs.User;
using EventHub.Domain.Entities;
using EventHub.Domain.Input;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventHub.Infrastructure.Interfaces.Repository
{
    public interface IEventSubscriptionsRepository
    {
        Task<int?> CreateEventSubscriptions(EventSubscriberInput input);
        Task<IEnumerable<CompleteEventDto>> GetEventsByUserId(int id);
        Task<IEnumerable<Events>> GetEventsByOwnerId(int id);
        Task<EventSubscribers> GetById(int id);
        Task<IEnumerable<UserDTO>> GetAllEventsSubscriptionsByEventId(int id);
        Task<bool> Delete(EventSubscriberInput input);
    }
}
