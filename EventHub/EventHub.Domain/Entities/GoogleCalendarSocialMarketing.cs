using System;
using System.Collections.Generic;
namespace EventHub.Domain.Entities
{
    public class GoogleCalendarSocialMarketing
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string HashCalendar { get; set; }
        public string CalendarLink { get; set; }
    }
}
