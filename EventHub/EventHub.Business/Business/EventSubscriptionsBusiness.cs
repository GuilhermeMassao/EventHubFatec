using EventHub.Domain.DTOs.Event;
using EventHub.Domain.Input;
using EventHub.Infraestructure.Repository;
using EventHub.Infrastructure.Interfaces.Repository;
using EventHub.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventHub.Business.Business
{
    public class EventSubscriptionsBusiness
    {
        private readonly IEventSubscriptionsRepository _subscriptionsRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEventRepository _eventRepository;

        public EventSubscriptionsBusiness
        (
            IEventSubscriptionsRepository subscriptionsRepository,
            IUserRepository userRepository,
            IEventRepository eventRepository
        )
        {
            _subscriptionsRepository = subscriptionsRepository;
            _userRepository = userRepository;
            _eventRepository = eventRepository;
        }

        public async Task<int?> CreateEventSubscriptions(EventSubscriberInput input)
        {
            if (await _userRepository.GetById(input.UserId) == null)
            {
                return null;
            }

            if (await _eventRepository.GetById(input.EventId) == null)
            {
                return null;
            }

            var eventInfo = await _eventRepository.GetById(input.EventId);
            var subscribers = await _subscriptionsRepository.GetAllEventsSubscriptionsByEventId(input.EventId);
      
            int numberSubscribers = 0;
            if (subscribers != null)
            {
                numberSubscribers = subscribers.Count();
            }

            if (eventInfo.TicketsLimit >= numberSubscribers)
            {
                return null;
            }

            var eventsSubscribed = await _subscriptionsRepository.GetEventsByUserId(input.UserId);
            if (eventsSubscribed.Where(x => x.Id == input.EventId).Select(s => s).Any())
            {
                return null;
            }

            var createdId = await _subscriptionsRepository.CreateEventSubscriptions(input);
            if (createdId != null)
            {
                return createdId.GetValueOrDefault();
            }

            return null;
        }

        public async Task<IEnumerable<Events>> GetEventsByUserSubscribed(int id)
        {
            return await _subscriptionsRepository.GetEventsByUserId(id);
        }

        public async Task<IEnumerable<Events>> GetCurrentEventsByOwnerId(int id)
        {
            return await _subscriptionsRepository.GetEventsByOwnerId(id);
        }

        public async Task<bool> Delete(int id)
        {
            if(_subscriptionsRepository.GetById(id) != null)
            {
                return await _subscriptionsRepository.Delete(id);
            }

            return false;
        }
    }
}
