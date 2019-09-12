namespace SocialConnection.Connections.Interfaces
{
    public interface IFacebookConnection<T> : ISocialConnection<T>
    {
        string GetAuthenticationUri(string appId, string redirectUri);
        T GetAccessToken(string appId, string appSecret, string code, string redirectUri);
    }
}