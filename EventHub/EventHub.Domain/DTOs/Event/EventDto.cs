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
        public EventDto(int userOwnerId, int id, string eventName,DateTime startDate, DateTime endDate,string eventDescription, string eventShortDescription)
        {
            this.UserOwnerId = userOwnerId;
            this.Id = id;
            this.EventName = eventName;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.EventDescription = eventDescription;
            this.EventShortDescription = eventShortDescription;
        }
        public int UserOwnerId { get; set; }
        public int Id { get; set; }
        public string EventName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string EventDescription { get; set; }
        public string EventShortDescription { get; set; }
    }
}
