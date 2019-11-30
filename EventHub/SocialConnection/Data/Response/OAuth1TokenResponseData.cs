namespace SocialConnection.Data.Response
{
    public class OAuth1TokenResponseData
    {
        public string Token { get; set; }
        public string TokenSecret { get; set; }
        public bool OAuthCallbackConfirmed { get; set; }
        public string TokenVerifier { get; set; }

        public OAuth1TokenResponseData() { }

        public OAuth1TokenResponseData(string token, string tokenSecret, bool oAuthCallbackConfirmed)
        {
            Token = token;
            TokenSecret = tokenSecret;
            OAuthCallbackConfirmed = oAuthCallbackConfirmed;
        }

        public OAuth1TokenResponseData(string token, string tokenVerifier)
        {
            Token = token;
            TokenVerifier = tokenVerifier;
        }
    }
}
