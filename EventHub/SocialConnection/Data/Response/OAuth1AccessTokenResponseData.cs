namespace SocialConnection.Data.Response
{
    public class OAuth1AccessTokenResponseData
    {
        public string AccessToken { get; set; }
        public string AccessTokenSecret { get; set; }

        public OAuth1AccessTokenResponseData(string accessToken, string accessTokenSecret)
        {
            AccessToken = accessToken;
            AccessTokenSecret = accessTokenSecret;
        }
    }
}