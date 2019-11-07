using EventHub.Application.Services.UserApplication;
using EventHub.Application.Services.UserApplication.Input;
using EventHub.WebApi.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EventHub.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UserApplication userApplication;

        public UserController(UserApplication userApplication)
        {
            this.userApplication = userApplication;
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public virtual async Task<IActionResult> CreateUser([FromBody] UserInput input)
        {
            if (PayloadValidator.ValidateObject(input))
            {
                return Created("New user created with sucess", await userApplication.CreateUser(input));
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public virtual async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await userApplication.GetById(id));
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public virtual async Task<IActionResult> GetAll()
        {
            return Ok(await userApplication.GetAll());
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(bool), 202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] UserInput input)
        {
            return Accepted(await userApplication.Update(id, input));
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return Ok(await userApplication.Delete(id));
        }
    }
}
