using EventHub.Application.Services.BaseServiceApplication;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EventHub.WebApi.Controllers.BaseController
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class Controller<TInput, TViewModel> : ControllerBase
        where TInput : class
        where TViewModel : class
    {
        private readonly IServiceApplication<TInput, TViewModel> _service;
    
        [HttpPost]
        [ProducesResponseType(typeof(int), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public virtual async Task<IActionResult> PostAsync([FromBody]TInput input)
        {
            return Created("", await _service.Insert(input));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public virtual async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpGet]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public virtual async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(int), 202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] TInput input)
        {
            return Accepted(await _service.Update(id, input));
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Delete([FromRoute] short id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}
