using SocialConnection.Data;
using SocialConnection.Data.Response;

namespace SocialConnection.Connections.Interfaces
{
    public interface IOAuth1Connection<T> : ISocialConnection<T>
    {
        RequestTokenResponseData GetRequestToken(string appKey, string appSecretKey, string callBackUrl);
        string GetAuthorizeTokenUri(string oauthToken);
        T GetAccessToken(OAuth1TokenResponseData tokenResponseData);
    }
}
