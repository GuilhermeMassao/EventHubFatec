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
        public GoogleCalendarOrganizer Organizer { get; set; }

        public GoogleCalendarPostContentData(string accessToken) : base(accessToken)
        {
        }
    }
}
