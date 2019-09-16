using System.Configuration;
using Microsoft.AspNetCore.Mvc;
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
        private IFacebookConnection<ClientFacebookAccessTokenResponseData> Facebook;

        public FacebookController(IFacebookConnection<ClientFacebookAccessTokenResponseData> facebook)
        {
            Facebook = facebook;
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
        public ActionResult<ClientFacebookAccessTokenResponseData> GetAccessToken(string code, string redirectUri)
        {
            return Facebook.GetAccessToken(AppId, AppSecret, code, redirectUri);
        }
        
        // GET social/facebook/post
        [HttpGet]
        [Route("post")]
        public ActionResult<ClientFacebookAccessTokenResponseData> Post(string code, string redirectUri)
        {
            return Facebook.GetAccessToken(AppId, AppSecret, code, redirectUri);
        }
    }
}
