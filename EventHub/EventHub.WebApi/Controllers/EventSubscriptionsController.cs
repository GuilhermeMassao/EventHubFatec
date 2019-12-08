using EventHub.Application.Services.EventSubscriptions;
using EventHub.Domain.Entities;
using EventHub.Domain.Input;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EventHub.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/subscriptions")]
    public class EventSubscriptionsController : ControllerBase
    {
        private readonly EventSubscriptionsApplication _application;
        public EventSubscriptionsController(EventSubscriptionsApplication application)
        {
            _application = application;
        }

        [HttpPost]
        [ProducesResponseType(typeof(EventSubscribers), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public virtual async Task<IActionResult> CreateEventSubscriptions([FromBody] EventSubscriberInput input)
        {
            var result = await _application.CreateEventSubscriptions(input);
            if (result != null)
            {
                return Created("", result);
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("subscribed/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public virtual async Task<IActionResult> GetEventsByUserSubscribed([FromRoute] int id)
        {
            var result = await _application.GetEventsByUserSubscribed(id);
            if(result != null)
            {
                return Ok(result);
            }

            return NoContent();
        }

        [HttpGet]
        [Route("owner/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public virtual async Task<IActionResult> GetCurrentEventsByOwnerId([FromRoute] int id)
        {
            var result = await _application.GetCurrentEventsByOwnerId(id);
            if(result != null)
            {
                return Ok(result);
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var sucess = await _application.Delete(id);
            if (sucess)
            {
                return Ok("Inscrição cacelada com sucesso!");
            }

            return NoContent();
        }
    }
}
