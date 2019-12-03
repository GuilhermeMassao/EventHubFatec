using System;
using System.Threading.Tasks;
using EventHub.Business.Business;
using EventHub.Domain.DTOs.Event;
using EventHub.Domain.Input;

namespace EventHub.Application.Services.EventApplication
{
    public class EventApplication
    {
        private readonly EventBusiness eventBusiness;

        public EventApplication(EventBusiness eventBusiness)
        {
            this.eventBusiness = eventBusiness;
        }
        public async Task<EventDto> CreateEvent(EventInput input)
        {
            return await eventBusiness.CreateEvent(input);
        }
    }
}
