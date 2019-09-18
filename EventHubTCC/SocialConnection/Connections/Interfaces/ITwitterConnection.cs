using SocialConnection.Data.Request;
using SocialConnection.Data.Response;

namespace SocialConnection.Connections.Interfaces
{
    public interface ITwitterConnection : IOAuth1Connection<TwitterAccessTokenResponseData>
    {
        PostResponseData PostTweet(TwitterPostContentData contentData);
    }
}
