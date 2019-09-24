namespace SocialConnection.Data.Response
{
    public class OAuth2AccessTokenResponseData
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public string RefreshToken { get; set; }

        public OAuth2AccessTokenResponseData(string accessToken, string tokenType, string refreshToken)
        {
            AccessToken = accessToken;
            TokenType = tokenType;
            RefreshToken = refreshToken;
        }

        public OAuth2AccessTokenResponseData(string accessToken, string tokenType)
        {
            AccessToken = accessToken;
            TokenType = tokenType;
        }
    }
}