using EventHub.Application.Services.SocialApplication;
using EventHub.Domain.Input;
using Microsoft.AspNetCore.Mvc;
using SocialConnection.Data.Response;
using System.Threading.Tasks;

namespace EventHub.WebApi.Controllers
{
    [Route("api/social")]
    [ApiController]
    public class SocialController : ControllerBase
    {
        private readonly SocialApplication socialApplication;

        public SocialController(SocialApplication socialApplication)
        {
            this.socialApplication = socialApplication;
        }

        [HttpGet]
        [Route("/twitter")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public virtual async Task<IActionResult> GetTwitterAtuhUri(string callbackUrl)
        {
            var result = await socialApplication.GetTwitterAtuhUri(callbackUrl);

            if (result != "")
            {
                //return Ok(Newtonsoft.Json.JsonConvert.DeserializeObject<RequestTokenResponseData>(result));
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("/twitter/access")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public virtual async Task<IActionResult> GetTwitterAccessToken([FromBody] OAuth1TokenResponseData input)
        {
            var result = await socialApplication.GetTwitterAccessToken(input);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("/google")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public virtual async Task<IActionResult> GetGoogleAtuhUri(string callbackUrl)
        {
            var result = await socialApplication.GetGoogleAtuhUri(callbackUrl);

            if (result != "")
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("/google/access")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public virtual async Task<IActionResult> GetGoogleAccessToken([FromBody] GoogleAccessTokenInput input)
        {
            var result = await socialApplication.GetGooleAccessToken(input);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
