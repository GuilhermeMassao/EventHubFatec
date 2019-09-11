using Microsoft.AspNetCore.Mvc;
using SocialConnection.Connections.Interfaces;
using SocialConnection.Data;

namespace EventHubApi.Controllers
{
    [Route("api/twitter/oauth")]
    [ApiController]
    public class TwitterController : ControllerBase
    {
        private const string CallbackUrl = "http://127.0.0.1:5001/";
        private ITwitterConnection<ClientTwitterAccessTokenData> Twitter;

        public TwitterController(ITwitterConnection<ClientTwitterAccessTokenData> twitter)
        {
            Twitter = twitter;
        }

        // GET api/twitter/oauth
        [HttpGet]
        public ActionResult<OAuth1TokenData> GetRequestToken()
        {
            return Twitter.GetRequestToken(CallbackUrl);
        }
        
        // GET api/twitter/oauth/authorize
        [HttpGet]
        [Route("authorize")]
        public ActionResult<string> GetAuthorizeTokenUri(string oatuhToken)
        {
            return Twitter.GetAuthorizeTokenUri(oatuhToken);
        }
        
        // GET api/twitter/oauth/access_token
        [HttpGet]
        [Route("access_token")]
        public ActionResult<ClientTwitterAccessTokenData> GetAccessToken(string oatuhToken, string verifierToken)
        {
            return Twitter.GetAccessToken(createOAuth1TokenDataForAccessToken(oatuhToken, verifierToken));
        }

        private OAuth1TokenData createOAuth1TokenDataForAccessToken(string oatuhToken, string verifierToken)
        {
            return new OAuth1TokenData(oatuhToken, verifierToken);
        }
    }
}