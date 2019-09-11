using SocialConnection;
using System.Web.Mvc;
using SocialConnection.Connections;
using SocialConnection.Data;

namespace EventHubTCC.Controllers
{
    public class TwitterController : Controller
    {
        public ActionResult Auth()
        {
            var twitter = new TwitterConnection();

            OAuth1TokenData token = twitter.GetRequestToken("http://127.0.0.1:5000/");

            return Redirect(twitter.GetAuthorizeTokenUri(token.Token));
        }
    }
}