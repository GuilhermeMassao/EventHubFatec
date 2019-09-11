namespace SocialConnection.Data
{
    public class ClientFacebookAccessTokenData
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }

        public ClientFacebookAccessTokenData(string accessToken, string tokenType)
        {
            AccessToken = accessToken;
            TokenType = tokenType;
        }
    }
}