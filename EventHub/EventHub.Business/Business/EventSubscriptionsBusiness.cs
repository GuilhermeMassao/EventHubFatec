using EventHub.Domain.DTOs.Event;
using EventHub.Domain.Input;
using EventHub.Infraestructure.Repository;
using EventHub.Infrastructure.Interfaces.Repository;
using EventHub.Infrastructure.Repositories;
using SocialConnection.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventHub.Business.Business
{
    public class EventSubscriptionsBusiness
    {
        private readonly string GOOGLE_APP_ID = "1096581191116-5ee78kmkthcahuhjr6bifpaooq34icct.apps.googleusercontent.com";
        private readonly string GOOGLE_APP_SECRET = "9ojQerHg5M3zdXkZ_fVBFXpr";

        private readonly IEventSubscriptionsRepository _subscriptionsRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IGoogleCalendarSocialMarketingRepository _googleCalendarSocialMarketingRepository;

        public EventSubscriptionsBusiness
        (
            IEventSubscriptionsRepository subscriptionsRepository,
            IUserRepository userRepository,
            IEventRepository eventRepository,
            IGoogleCalendarSocialMarketingRepository googleCalendarSocialMarketingRepository
        )
        {
            _subscriptionsRepository = subscriptionsRepository;
            _userRepository = userRepository;
            _eventRepository = eventRepository;
            _googleCalendarSocialMarketingRepository = googleCalendarSocialMarketingRepository;
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

            if (numberSubscribers >= eventInfo.TicketsLimit)
            {
                return null;
            }

            var eventsSubscribed = await _subscriptionsRepository.GetEventsByUserId(input.UserId);
            if (eventsSubscribed != null && 
                eventsSubscribed.Where(x => x.EventId == input.EventId).Select(s => s).Any()
            )
            {
                return null;
            }

            var createdId = await _subscriptionsRepository.CreateEventSubscriptions(input);
            if (createdId != null)
            {
                var userGoogleRefreshToken = await _userRepository.GetGoogleTokenByUserId(input.UserId);
                if (userGoogleRefreshToken != null) {
                    var eventGoogleInfo = await _googleCalendarSocialMarketingRepository.GetByEventId(input.EventId);
                    if (eventGoogleInfo != null) {
                        GoogleConnection google = new GoogleConnection();
                        var accessToken = google.RefreshAccessToken(GOOGLE_APP_ID, GOOGLE_APP_SECRET, userGoogleRefreshToken.GoogleRefreshToken);
                        try
                        {
                            google.SubscribeAgenda(accessToken.AccessToken, eventGoogleInfo.HashCalendar);
                        } catch (Exception) { }
                    }
                }
                return createdId.GetValueOrDefault();
            }

            return null;
        }

        public async Task<IEnumerable<CompleteEventDto>> GetEventsByUserSubscribed(int id)
        {
            return await _subscriptionsRepository.GetEventsByUserId(id);
        }

        public async Task<IEnumerable<CompleteEventDto>> GetCurrentEventsByOwnerId(int id)
        {
            return await _subscriptionsRepository.GetEventsByOwnerId(id);
        }

        public async Task<bool> Delete(EventSubscriberInput input)
        {
            if(_subscriptionsRepository.GetById(input.UserId) == null)
            {
                return false;
            }

            if (_eventRepository.GetById(input.EventId) == null)
            {
                return false;
            }

            return await _subscriptionsRepository.Delete(input);
        }
    }
}
