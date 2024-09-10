using _2TDSPK.Database.Models;
using _2TDSPK.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace _2TDSPK.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IRepository<User> _userRepository; 


        public UserController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Post([FromBody] User user)
        {
            _userRepository.Add(user);
            return Created();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<User>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]

        public IActionResult GetAll()
        {
            var users = _userRepository.GetAll();
            return Ok(users);
        }


        [HttpPatch]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Patch([FromBody] User user)
        {
            _userRepository.Update(user);
            return Ok();
        }


        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Delete([FromBody] User user)
        {
            _userRepository.Delete(user);
            return Created();
        }
    }
}
