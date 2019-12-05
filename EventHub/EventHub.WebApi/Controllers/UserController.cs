using EventHub.Application.Services.UserApplication;
using EventHub.Domain.DTOs.User;
using EventHub.Domain.Entities;
using EventHub.Domain.Input;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EventHub.WebApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UserApplication userApplication;

        public UserController(UserApplication userApplication)
        {
            this.userApplication = userApplication;
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserDTO), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public virtual async Task<IActionResult> CreateUser([FromBody] UserInput input)
        {
            var result = await userApplication.CreateUser(input);

            if (result != null)
            {
                return Created("", result);
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public virtual async Task<IActionResult> GetById([FromRoute] int id)
        {
            var user = await userApplication.GetById(id);
            if (user == null)
            {
                return NoContent();
            }

            return Ok(user);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(bool), 202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] UserInput input)
        {
            var sucess = await userApplication.Update(id, input);
            if (sucess)
            {
                return Accepted(sucess);
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var sucess = await userApplication.Delete(id);
            if (sucess)
            {
                return Ok("Usuário Inativado com sucesso!");
            }

            return NoContent();
        }

        [HttpPost]
        [Route("/login")]
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public virtual async Task<IActionResult> UserLogin([FromBody] UserLoginInput input)
        {
            var result = await userApplication.UserLogin(input);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Usuário ou senha inválidos!");
        }

        [HttpPut]
        [Route("/twitter/token/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public virtual async Task<IActionResult> UpdateTwitterToken([FromRoute] int id, [FromBody] UserTwitterTokensInput input)
        {
            var result = await userApplication.UpdateTwitterToken(id, input);

            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("/google/token/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public virtual async Task<IActionResult> UpdateGoogleToken([FromRoute] int id, [FromBody] GoogleRefreshTokenInput input)
        {
            var result = await userApplication.UpdateGoogleToken(id, input);

            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
