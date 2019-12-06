using System;

namespace EventHub.Domain.Input
{ 
    public class EventInput
    {
        public int UserOwnerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string EventShortDescription { get; set; }
        public int TicketsLimit { get; set; }
        public EventAdress Adress { get; set; }
        public bool TwitterLogin { get; set; }
        public bool GoogleLogin { get; set; }
    }
}
