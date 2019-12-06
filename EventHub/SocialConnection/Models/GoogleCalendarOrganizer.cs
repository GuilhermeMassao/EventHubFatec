namespace SocialConnection.Models
{
    public class GoogleCalendarOrganizer
    {
        public GoogleCalendarOrganizer(string displayName, string email)
        {
            DisplayName = displayName;
            Email = email;
        }
        public string DisplayName { get; set; }
        public string Email { get; set; }
    }
}