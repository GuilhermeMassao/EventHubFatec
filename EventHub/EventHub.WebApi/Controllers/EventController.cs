using System.Threading.Tasks;
using EventHub.Application.Services.EventApplication;
using EventHub.Application.Services.EventApplication.Input;
using Microsoft.AspNetCore.Mvc;

namespace EventHub.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventApplication eventApplication;

        public EventController(EventApplication eventApplication)
        {
            this.eventApplication = eventApplication;
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public virtual async Task<IActionResult> CreateUser([FromBody] EventInput input)
        {
           var newEvent = await eventApplication.CreateEventAsync(input);

            if(newEvent != null) {
                return Created("New event created with sucess", newEvent);
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
            var eventGet = await eventApplication.GetById(id);
            if (eventGet == null)
            {
                return NoContent();
            }
            return Ok(eventGet);
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public virtual async Task<IActionResult> GetAll()
        {
            return Ok(await eventApplication.GetAll());
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(bool), 202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] EventInput input)
        {
            return Accepted(await eventApplication.Update(id, input));
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(503)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return Ok(await eventApplication.Delete(id));
        }
    }
}


/*
 {
  "userId": 1,
  "startDate": "2019-11-12T19:05:42.964Z",
  "endDate": "2019-11-12T19:05:42.964Z",
  "eventName": "Event test",
  "eventDescription": "Test description",
  "adress": {
    "publicPlace": {
      "placeName": "Place Name"
    },
    "city": "City",
    "uf": "UF",
    "cep": "CEP",
    "neighborhood": "Neighborhood",
    "adressComplement": "AdressComplement",
    "adressNumber": "213"
  }
}
 */
