using System.Threading.Tasks;
using AutoMapper;
using EventHub.Application.Services.EventApplication.Input;
using EventHub.Application.Utils;
using EventHub.Business.Business;
using EventHub.Domain;

namespace EventHub.Application.Services.EventApplication
{
    public class EventApplication
    {
        private readonly EventBusiness eventBusiness;
        private readonly IMapper inputToEntity;

        public EventApplication(EventBusiness eventBusiness, IMapper inputToEntity)
        {
            this.eventBusiness = eventBusiness;
            this.inputToEntity = inputToEntity;
        }

        public async Task<Event> CreateEventAsync(EventInput input)
        {
            if(PayloadValidator.ValidateObject(input))
            {
                return await eventBusiness.CreateEvent(inputToEntity.Map<EventInput, Event>(input),
                    inputToEntity.Map<EventAdress, Adress>(input.Adress),
                    inputToEntity.Map<AdressPublicPlace, PublicPlace>(input.Adress.PublicPlace));
            }

            return null;
        }
    }
}
