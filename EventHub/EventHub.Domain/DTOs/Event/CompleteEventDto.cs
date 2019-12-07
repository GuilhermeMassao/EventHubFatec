using EventHub.Domain.Entities;
using System;

namespace EventHub.Domain.DTOs.Event
{
    public class CompleteEventDto
    {
        public int UserOwnerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string EventShortDescription { get; set; }
        public int TicketsLimit { get; set; }
        public int AdressId { get; set; }
        public int PublicPlaceId { get; set; }
        public string PlaceName { get; set; }
        public string City { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string Neighborhood { get; set; }
        public string AdressComplement { get; set; }
        public string AdressNumber { get; set; }
    }
}
