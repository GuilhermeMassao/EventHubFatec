using SocialConnection.Data.Request;
using SocialConnection.Data.Response;

namespace SocialConnection.Connections.Interfaces
{
    public interface IGoogleConnection: IOAuth2Connection<OAuth2AccessTokenResponseData>
    {
        PostResponseData CreateEvent(GoogleCalendarPostContentData contentData);
    }
}