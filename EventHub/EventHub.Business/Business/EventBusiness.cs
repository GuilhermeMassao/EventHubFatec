using System.Collections.Generic;
using System.Threading.Tasks;
using EventHub.Domain.DTOs.Event;
using EventHub.Domain.Entities;
using EventHub.Infrastructure.Interfaces.Repository;

namespace EventHub.Business.Business
{
    public class EventBusiness
    {
        private readonly IAdressRepository _adressRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IPublicPlaceRepository _publicPlaceRepository;

        public EventBusiness(IAdressRepository adressRepository, IEventRepository eventRepository, IPublicPlaceRepository publicPlaceRepository)
        {
            _adressRepository = adressRepository;
            _eventRepository = eventRepository;
            _publicPlaceRepository = publicPlaceRepository;
        }

        public async Task<EventDto> CreateEvent(Event newEvent, Adress adress)
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

        public async Task<IEnumerable<PublicPlace>> GetPublicPlaces()
        {
            return await _publicPlaceRepository.GetAll();
        }

    }
}

