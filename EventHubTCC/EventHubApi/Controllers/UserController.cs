using System.Collections.Generic;
using EventHubApi.Bussiness;
using EventHubApi.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace EventHubApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private UserService userService;

        public UserController(UserService userRepository)
        {
            userService = userRepository;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> GetAll()
        {
            return userService.GetAllUsers();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
