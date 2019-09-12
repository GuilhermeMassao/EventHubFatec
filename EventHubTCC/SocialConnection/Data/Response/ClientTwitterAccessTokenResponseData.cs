namespace SocialConnection.Data.Response
{
    public class ClientTwitterAccessTokenResponseData
    {
        public string AccessToken { get; set; }
        public string AccessTokenSecret { get; set; }
        public string UserId { get; set; }
        public string UserScreenName { get; set; }

        public ClientTwitterAccessTokenResponseData(string accessToken, string accessTokenSecret, string userId, string userScreenName)
        {
            AccessToken = accessToken;
            AccessTokenSecret = accessTokenSecret;
            UserId = userId;
            UserScreenName = userScreenName;
        }
    }
}