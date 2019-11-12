using System;

namespace EventHub.Application.Services.EventApplication.Input
{ 
    public class EventInput
    {
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public EventAdress Adress { get; set; }
    }
}
