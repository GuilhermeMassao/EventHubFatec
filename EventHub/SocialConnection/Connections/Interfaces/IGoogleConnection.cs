using System.Collections.Generic;
using SocialConnection.Data.Request;
using SocialConnection.Data.Response;

namespace SocialConnection.Connections.Interfaces
{
    public interface IGoogleConnection: IOAuth2Connection<OAuth2AccessTokenResponseData>
    {
        PostResponseData CreateEvent(GoogleCalendarPostContentData contentData);
        bool DeleteEvent(string accessToken, string calendarId, string eventId);
        IEnumerable<GoogleAgendaResponseData> GetAgendaList(string accessToken);
    }
}
