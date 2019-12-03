using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventHub.Domain.DTOs.Event;
using EventHub.Domain.Input;

namespace EventHub.Business.Business
{
    public class EventBusiness
    {
        public Task<EventDto> CreateEvent(EventInput input)
        {
            throw new NotImplementedException();
        }
    }
}
