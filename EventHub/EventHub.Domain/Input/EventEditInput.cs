using EventHub.Domain.Entities;
using System;

namespace EventHub.Domain.Input
{
    public class EventEditInput
    {
        public int UserOwnerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string EventShortDescription { get; set; }
        public int TicketsLimit { get; set; }
        public Adress Adress { get; set; }
    }
}
