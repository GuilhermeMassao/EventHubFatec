using AutoMapper;
using EventHub.Business.Business;
using EventHub.Domain.DTOs.Event;
using EventHub.Domain.Entities;
using EventHub.Domain.Input;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventHub.Application.Services.EventSubscriptions
{
    public class EventSubscriptionsApplication
    {
        private readonly EventSubscriptionsBusiness _business;
        private readonly IMapper _inputToEntity;
        public EventSubscriptionsApplication
        (
            EventSubscriptionsBusiness business,
            IMapper inputToEntity
        )
        {
            _business = business;
            _inputToEntity = inputToEntity;
        }

        public async Task<EventSubscribers> CreateEventSubscriptions(EventSubscriberInput input)
        {
            var createdId = await _business.CreateEventSubscriptions(input);
            if (createdId != null)
            {
                var entity = new EventSubscribers
                {
                    Id = createdId.GetValueOrDefault(),
                    EventId = input.EventId,
                    UserId = input.UserId
                };

                return entity;
            }

            return default(EventSubscribers);
        }

        public async Task<IEnumerable<CompleteEventDto>> GetEventsByUserSubscribed(int id)
        {
            return await _business.GetEventsByUserSubscribed(id);
        }

        public async Task<IEnumerable<CompleteEventDto>> GetCurrentEventsByOwnerId(int id)
        {
            return await _business.GetCurrentEventsByOwnerId(id);
        }

        public async Task<bool> Delete(EventSubscriberInput input)
        {
            return await _business.Delete(input);
        }
    }
}
