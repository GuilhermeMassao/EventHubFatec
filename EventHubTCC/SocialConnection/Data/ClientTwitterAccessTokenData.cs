namespace SocialConnection.Data
{
    public class ClientTwitterAccessTokenData
    {
        public string AccessToken { get; set; }
        public string AccessTokenSecret { get; set; }
        public string UserId { get; set; }
        public string UserScreenName { get; set; }

        public ClientTwitterAccessTokenData(string accessToken, string accessTokenSecret, string userId, string userScreenName)
        {
            AccessToken = accessToken;
            AccessTokenSecret = accessTokenSecret;
            UserId = userId;
            UserScreenName = userScreenName;
        }
    }
}