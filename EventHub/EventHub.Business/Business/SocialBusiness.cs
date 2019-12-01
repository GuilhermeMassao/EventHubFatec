using EventHub.Domain.Input;
using SocialConnection.Connections;
using SocialConnection.Data.Response;
using SocialConnection.Exceptions;
using System.Threading.Tasks;

namespace EventHub.Business.Business
{
    public class SocialBusiness
    {
        private readonly string TWITTER_APP_KEY = "QZ3bVW2dy0fqi2kQ4XynqOJXO";
        private readonly string TWITTER_APP_KEY_SECRET = "Wj9pf4xSRa0lxzcMLS0IU3iSD86GBaquSM3lUpI8FaZHBerueA";

        private readonly string GOOGLE_APP_ID = "1096581191116-5ee78kmkthcahuhjr6bifpaooq34icct.apps.googleusercontent.com";
        private readonly string GOOGLE_APP_SECRET = "9ojQerHg5M3zdXkZ_fVBFXpr";


        public Task<string> GetTwitterAtuhUri(string callbackurl)
        {
            TwitterConnection twitter = new TwitterConnection();

            return Task.Run(() =>
            {
                try
                {
                    var requestTokenData = twitter.GetRequestToken(TWITTER_APP_KEY, TWITTER_APP_KEY_SECRET, callbackurl);
                    if(requestTokenData.OAuthCallbackConfirmed)
                    {
                        return twitter.GetAuthorizeTokenUri(requestTokenData.Token);
                    }
                    return "";
                } catch(CouldNotConnectException e)
                {
                    return "";
                }
            });
        }

        public Task<TwitterAccessTokenResponseData> GetTwitterAccessToken(OAuth1TokenResponseData input)
        {
            TwitterConnection twitter = new TwitterConnection();

            return Task.Run(() =>
            {
                try
                {
                    return twitter.GetAccessToken(input);
                }
                catch (CouldNotConnectException e)
                {
                    return null;
                }
            });
        }

        public Task<string> GetGoogleAtuhUri(string callbackurl)
        {
            GoogleConnection google = new GoogleConnection();

            return Task.Run(() =>
            {
                try
                {
                    return google.GetAuthenticationUri(GOOGLE_APP_ID, callbackurl);
                }
                catch (CouldNotConnectException e)
                {
                    return "";
                }
            });
        }

        public Task<OAuth2AccessTokenResponseData> GetGooleAccessToken(GoogleAccessTokenInput input)
        {
            GoogleConnection google = new GoogleConnection();

            return Task.Run(() =>
            {
                try
                {
                    return google.GetAccessToken(GOOGLE_APP_ID, GOOGLE_APP_SECRET, input.Code, input.CallbackUrl);
                }
                catch (CouldNotConnectException e)
                {
                    return null;
                }
            });
        }
    }
}
