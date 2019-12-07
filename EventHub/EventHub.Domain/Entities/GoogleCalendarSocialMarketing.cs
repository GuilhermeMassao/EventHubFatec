using System;
using System.Collections.Generic;
namespace EventHub.Domain.Entities
{
    public class GoogleCalendarSocialMarketing
    {
        public GoogleCalendarSocialMarketing(int eventId, string hashCalendar, string calendarLink)
        {
            EventId = eventId;
            HashCalendar = hashCalendar;
            CalendarLink = calendarLink;
        }
        public int Id { get; set; }
        public int EventId { get; set; }
        public string HashCalendar { get; set; }
        public string CalendarLink { get; set; }
    }
}
