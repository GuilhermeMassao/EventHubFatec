using System.Configuration;
using Microsoft.AspNetCore.Mvc;
using SocialConnection.Connections;
using SocialConnection.Connections.Interfaces;
using SocialConnection.Data.Response;
using ControllerBase = Microsoft.AspNetCore.Mvc.ControllerBase;

namespace EventHubApi.Controllers.Social
{
    [Route("social/facebook")]
    [ApiController]
    public class FacebookController : ControllerBase
    {
        private static readonly string AppId = ConfigurationManager.AppSettings["facebook.appid"];
        private static readonly string AppSecret = ConfigurationManager.AppSettings["facebook.appsecret"];
        private IOAuth2Connection<OAuth2AccessTokenResponseData> Facebook;

        public FacebookController()
        {
            Facebook = new FacebookConnection();
        }

        // GET social/facebook/oauth
        [HttpGet]
        [Route("oauth")]
        public ActionResult<string> GetAuthenticationUri(string redirectUri)
        {
            return Facebook.GetAuthenticationUri(AppId, redirectUri);
        }
        
        // GET social/facebook/oauth/access_token
        [HttpGet]
        [Route("oauth/access_token")]
        public ActionResult<OAuth2AccessTokenResponseData> GetAccessToken(string code, string redirectUri)
        {
            return Facebook.GetAccessToken(AppId, AppSecret, code, redirectUri);
        }
        
        // GET social/facebook/post
        [HttpGet]
        [Route("post")]
        public ActionResult<OAuth2AccessTokenResponseData> Post(string code, string redirectUri)
        {
            return Facebook.GetAccessToken(AppId, AppSecret, code, redirectUri);
        }
    }
}
