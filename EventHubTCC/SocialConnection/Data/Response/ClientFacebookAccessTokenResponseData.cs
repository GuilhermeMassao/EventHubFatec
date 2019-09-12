namespace SocialConnection.Data.Response
{
    public class ClientFacebookAccessTokenResponseData
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }

        public ClientFacebookAccessTokenResponseData(string accessToken, string tokenType)
        {
            AccessToken = accessToken;
            TokenType = tokenType;
        }
    }
}