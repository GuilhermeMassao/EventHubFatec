using System.Configuration;
using Microsoft.AspNetCore.Mvc;
using SocialConnection.Connections;
using SocialConnection.Connections.Interfaces;
using SocialConnection.Data.Request;
using SocialConnection.Data.Response;
using ControllerBase = Microsoft.AspNetCore.Mvc.ControllerBase;

namespace EventHubApi.SocialTestApi
{
    [Route("social/google/calendar")]
    [ApiController]
    public class GoogleCalendarController : ControllerBase
    {
        private static readonly string AppId = ConfigurationManager.AppSettings["google.calendar.appid"];
        private static readonly string AppSecret = ConfigurationManager.AppSettings["google.calendar.appsecret"];
        private IGoogleConnection Calendar;

        public GoogleCalendarController()
        {
            Calendar = new GoogleConnection();
        }

        // GET social/google/calendar/oauth
        [HttpGet]
        [Route("oauth")]
        public ActionResult<string> GetAuthenticationUri(string redirectUri)
        {
            return Calendar.GetAuthenticationUri(AppId, redirectUri);
        }
        
        // GET social/google/calendar/oauth/access_token
        [HttpGet]
        [Route("oauth/access_token")]
        public ActionResult<OAuth2AccessTokenResponseData> GetAccessToken(string code, string redirectUri)
        {
            return Calendar.GetAccessToken(AppId, AppSecret, code, redirectUri);
        }
        
        // GET social/google/calendar/oauth/access_token
        [HttpGet]
        [Route("oauth/refresh_token")]
        public ActionResult<OAuth2AccessTokenResponseData> RefreshAccessToken(string refreshToken)
        {
            // Deixar esse método junto com o EndPoint do access_token
            return Calendar.RefreshAccessToken(AppId, AppSecret, refreshToken);
        }
        
        // GET social/google/calendar/post
        [HttpGet]
        [Route("post")]
        public ActionResult<PostResponseData> Post([FromBody] GoogleCalendarPostContentData content)
        {
            return Calendar.CreateEvent(content);
        }
        
        // GET social/google/calendar/delete
        [HttpGet]
        [Route("delete")]
        public ActionResult<bool> DeleteEvent([FromBody] string accessToken, string calendarId, string eventId)
        {
            return Calendar.DeleteEvent(accessToken, calendarId, eventId);
        }
    }
}
