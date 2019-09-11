namespace SocialConnection.Connections.Interfaces
{
    public interface IFacebookConnection<T> : ISocialConnection<T>
    {
        string GetAuthenticationUri(string redirectUri);
        T GetAccessToken(string code, string redirectUri);
    }
}