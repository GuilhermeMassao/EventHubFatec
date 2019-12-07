namespace EventHub.Domain.Entities
{
    public class GoogleCalendarSocialMarketing
    {
        public GoogleCalendarSocialMarketing(int eventId, string hashCalendar, string hashEvent, string calendarLink)
        {
            EventId = eventId;
            HashCalendar = hashCalendar;
            HashEvent = hashEvent;
            CalendarLink = calendarLink;
        }
        public int Id { get; set; }
        public int EventId { get; set; }
        public string HashCalendar { get; set; }
        public string HashEvent { get; set; }
        public string CalendarLink { get; set; }
    }
}
