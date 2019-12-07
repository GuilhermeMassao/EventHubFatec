using System;
using System.Collections;
using System.Collections.Generic;
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
                _inputToEntity.Map<EventAdress, Adress>(input.Adress),
                input.TwitterLogin,
                input.GoogleLogin);
        }

        public async Task<bool> EditEvent(int id, EventEditInput input)
        {
            return await eventBusiness.EditEvent(id, _inputToEntity.Map<EventEditInput, Event>(input), input.Adress);
        }

        public async Task<IEnumerable<PublicPlace>> GetPublicPlaces()
        {
            return await eventBusiness.GetPublicPlaces();
        }
    }
}
