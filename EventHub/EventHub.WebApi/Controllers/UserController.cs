using EventHub.Application.Services.UserApplication;
using EventHub.Application.Services.UserApplication.Input;
using EventHub.Domain.Input;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EventHub.WebApi.Controllers
{
    [Route("api/[controller]")]
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
        [ProducesResponseType(503)]
        public virtual async Task<IActionResult> CreateUser([FromBody] UserInput input)
        {
            var result = await userApplication.CreateUser(input);

            if (result) // refatorar depois para retornar o object (ou ver se o front consegue se virar e dar um get para se logar)
            {
                return Created("New user created with sucess", result);
            }

            return BadRequest("Can't create new user");
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

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public virtual async Task<IActionResult> GetAll()
        {
            return Ok(userApplication.GetAll().Result);
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
        [ProducesResponseType(503)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return Ok(await userApplication.Delete(id));
        }

        [HttpPost]
        [Route("/login")]
        [ProducesResponseType(200)]
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
            return NoContent();
        }
    }
}
