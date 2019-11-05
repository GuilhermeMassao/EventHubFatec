﻿using EventHub.Application.Interfaces.BaseInterfaces;
using EventHub.WebApi.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EventHub.WebApi.Controllers.BaseController
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class Controller<TInput, TEntity> : ControllerBase
        where TInput : class
        where TEntity : class
    {
        private readonly IServiceApplication<TInput, TEntity> _service;
    
        public Controller(IServiceApplication<TInput, TEntity> service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public virtual async Task<IActionResult> PostAsync([FromBody]TInput input)
        {
            if(PayloadValidator.ValidateObject(input)){
                return Created("", await _service.Insert(input));
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
            return Ok(await _service.GetById(id));
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public virtual async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(bool), 202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] TInput input)
        {
            return Accepted(await _service.Update(id, input));
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}
