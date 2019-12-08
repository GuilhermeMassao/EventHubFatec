using System;

namespace EventHub.Domain.DTOs.Event
{
    public class Events
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string EventName { get; set; }
        public string EventShortDescription { get; set; }
        public int TicketsLimit { get; set; }
    }
}
