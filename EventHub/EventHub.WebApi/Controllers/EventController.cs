using EventHub.Application.Services.EventApplication;
using EventHub.Business.Business;
using EventHub.Domain.DTOs.Event;
using EventHub.Domain.Input;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace EventHub.WebApi.Controllers
{
    [Route("api/event")]
    [ApiController]
    public class EventController : ControllerBase
    {

        private readonly EventApplication eventApplication;
        private readonly EventBusiness eventBusiness;
        public EventController(EventApplication eventApplication, EventBusiness eventBusiness)
        {
            this.eventApplication = eventApplication;
            this.eventBusiness = eventBusiness;
        }
        [HttpPost]
        [Route("/api/events")]
        [ProducesResponseType(typeof(CompleteEventDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public virtual async Task<IActionResult> GetAllButUser([FromBody] EventFilterDto filter)
        {
            var result = await eventApplication.GetAllButUser(filter.UserId);

            var resultsFiltered = eventBusiness.FilterEvents(filter, result,out var total);
            if (result != null)
            {
                var retorno = new EventFilterReturnDto()
                {
                    Data = resultsFiltered,
                    RecordsFiltered = total,
                    RecordsTotal = result.Count(),
                    draw = filter.Draw,
                };
                return Ok(retorno);
            }

            return BadRequest();
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public virtual async Task<IActionResult> CreateEvent([FromBody] EventInput input)
        {
            var result = await eventApplication.CreateEvent(input);

            if (result != null)
            {
                return Created("Evento criado com sucesso!", result);
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("/api/event/{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public virtual async Task<IActionResult> EditEvent([FromRoute] int id, [FromBody] EventEditInput input)
        {
            var result = await eventApplication.EditEvent(id, input);

            if (result)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("/api/event/inactive/{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public virtual async Task<IActionResult> InactiveEvent([FromRoute] int id, [FromBody] DeleteEventInput input)
        {
            var result = await eventApplication.InactiveEvent(id, input);

            if (result)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("/api/event/{id}")]
        [ProducesResponseType(typeof(CompleteEventDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public virtual async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await eventApplication.GetById(id);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("/api/event/user/{id}")]
        [ProducesResponseType(typeof(CompleteEventDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public virtual async Task<IActionResult> GetByUserId([FromRoute] int id)
        {
            var result = await eventApplication.GetByUserId(id);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("/api/event/active")]
        [ProducesResponseType(typeof(CompleteEventDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public virtual async Task<IActionResult> GetAllActiveEvents()
        {
            var result = await eventApplication.GetAllActiveEvents();

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("/public-places")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public virtual async Task<IActionResult> GetPublicPlaces()
        {
            var result = await eventApplication.GetPublicPlaces();

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
