using System;
using System.Threading.Tasks;
using AutoMapper;
using EventHub.Business.Business;
using EventHub.Domain.DTOs.Event;
using EventHub.Domain.Entities;
using EventHub.Domain.Input;

namespace EventHub.Application.Services.EventApplication
{
    public class EventApplication
    {
        private readonly EventBusiness eventBusiness;
        private readonly IMapper _inputToEntity;

        public EventApplication(EventBusiness eventBusiness, IMapper inputToEntity)
        {
            this.eventBusiness = eventBusiness;
            _inputToEntity = inputToEntity;
        }
        public async Task<EventDto> CreateEvent(EventInput input)
        {
            return await eventBusiness.CreateEvent(_inputToEntity.Map<EventInput, Event>(input),
                _inputToEntity.Map<EventAdress, Adress>(input.Adress));
        }
    }
}
