using SocialConnection.Models;

namespace SocialConnection.Data.Request
{
    public class GoogleCalendarPostContentData : BasePostContentRequestData
    {
        public string CalendarId { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int AdditionalGuests { get; set; }
        public GoogleCalendarOrganizer Organizer { get; set; }

        public GoogleCalendarPostContentData(string accessToken, string calendarId, string start, string end, string summary, string description, string location, int additionalGuests, GoogleCalendarOrganizer organizer) : base(accessToken)
        {
            CalendarId = calendarId;
            Start = start;
            End = end;
            Summary = summary;
            Description = description;
            Location = location;
            AdditionalGuests = additionalGuests;
            Organizer = organizer;
        }
    }
}
