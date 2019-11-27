using EventHub.Application.Services.SocialApplication;
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
    }
}
