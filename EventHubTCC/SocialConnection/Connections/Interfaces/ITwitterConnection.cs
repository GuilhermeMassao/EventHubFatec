using SocialConnection.Data;

namespace SocialConnection.Connections.Interfaces
{
    public interface ITwitterConnection<T> : ISocialConnection<T>
    {
        OAuth1TokenData GetRequestToken(string callBackUrl);
        string GetAuthorizeTokenUri(string oauthToken);
        T GetAccessToken(OAuth1TokenData tokenData);
    }
}