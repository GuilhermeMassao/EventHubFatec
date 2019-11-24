using SocialConnection.Connections;
using SocialConnection.Exceptions;
using System.Threading.Tasks;

namespace EventHub.Business.Business
{
    public class SocialBusiness
    {
        private readonly string TWITTER_APP_KEY = "QZ3bVW2dy0fqi2kQ4XynqOJXO";
        private readonly string TWITTER_APP_KEY_SECRET = "Wj9pf4xSRa0lxzcMLS0IU3iSD86GBaquSM3lUpI8FaZHBerueA";


        public Task<string> GetTwitterAtuhUri(string callbackurl)
        {
            TwitterConnection twitter = new TwitterConnection();

            return Task.Run(() =>
            {
                try
                {
                    return Newtonsoft.Json.JsonConvert.SerializeObject(twitter.GetRequestToken(TWITTER_APP_KEY, TWITTER_APP_KEY_SECRET, callbackurl));
                } catch(CouldNotConnectException e)
                {
                    return "";
                }
            });
        }
    }
}
