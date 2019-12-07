﻿using EventHub.Application.Services.EventApplication;
using EventHub.Domain.DTOs.Event;
using EventHub.Domain.Input;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventHub.WebApi.Controllers
{
    [Route("api/event")]
    [ApiController]
    public class EventController : ControllerBase
    {

        private readonly EventApplication eventApplication;

        public EventController(EventApplication eventApplication)
        {
            this.eventApplication = eventApplication;
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
