﻿using System;

namespace EventHub.Domain.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AdressId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
    }
}