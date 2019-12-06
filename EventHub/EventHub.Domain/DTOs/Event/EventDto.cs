using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Domain.DTOs.Event
{
    public class EventDto
    {
        public EventDto(int id, string eventName)
        {
            Id = id;
            EventName = eventName;
        }
        public int Id { get; set; }
        public string EventName { get; set; }
    }
}
