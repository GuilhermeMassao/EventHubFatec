using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventHub.Domain.DTOs.Event;
using EventHub.Domain.Entities;
using EventHub.Domain.Input;
using EventHub.Infrastructure.Interfaces.Repository;

namespace EventHub.Business.Business
{
    public class EventBusiness
    {
        private readonly IAdressRepository _adressRepository;
        private readonly IEventRepository _eventRepository;

        public EventBusiness(IAdressRepository adressRepository, IEventRepository eventRepository)
        {
            _adressRepository = adressRepository;
            _eventRepository = eventRepository;
        }
        public async Task<EventDto> CreateEvent(Event newEvent, Adress adress, PublicPlace publicPlace)
        {
            var adressResultId = await _adressRepository.CreateAdress(adress);

            if(adressResultId != null)
            {
                newEvent.AdressId = adressResultId.GetValueOrDefault();

                var eventResultId = await _eventRepository.CreateEvent(newEvent);

                if(eventResultId != null)
                {
                    return new EventDto(eventResultId.GetValueOrDefault(), newEvent.EventName);
                } else
                {
                    _adressRepository.Delete(adressResultId.GetValueOrDefault());
                }
            }
            return null;
        }   

    }
}

