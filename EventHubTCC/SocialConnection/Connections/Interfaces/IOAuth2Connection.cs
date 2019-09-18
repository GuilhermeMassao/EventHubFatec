namespace SocialConnection.Connections.Interfaces
{
    public interface IOAuth2Connection<T> : ISocialConnection<T>
    {
        string GetAuthenticationUri(string appId, string redirectUri);
        T GetAccessToken(string appId, string appSecret, string code, string redirectUri);
        T RefreshAccessToken(string appId, string appSecret, string refreshToken);
    }
}