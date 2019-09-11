namespace SocialConnection.Data
{
    public class OAuth1TokenData
    {
        public string Token { get; set; }
        public string TokenSecret { get; set; }
        public bool OAuthCallbackConfirmed { get; set; }
        public string TokenVerifier { get; set; }

        public OAuth1TokenData(string token, string tokenSecret, bool oAuthCallbackConfirmed)
        {
            Token = token;
            TokenSecret = tokenSecret;
            OAuthCallbackConfirmed = oAuthCallbackConfirmed;
        }

        public OAuth1TokenData(string token, string tokenVerifier)
        {
            Token = token;
            TokenVerifier = tokenVerifier;
        }

        public OAuth1TokenData(string token, string tokenSecret, bool oAuthCallbackConfirmed, string tokenVerifier)
        {
            Token = token;
            TokenSecret = tokenSecret;
            OAuthCallbackConfirmed = oAuthCallbackConfirmed;
            TokenVerifier = tokenVerifier;
        }
    }
}