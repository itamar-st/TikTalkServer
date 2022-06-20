using Domain;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //controller for the User model
    public class userController : ControllerBase
    {
        private IUsersService _userService;

        public userController()
        {
            this._userService = new UserService();
        }


        // get all users
        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<User> users = _userService.Get();
            if(users == null) return NotFound();

            return Ok(users);
        }


        // get user
        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var user = _userService.Get(id);
            if(user == null) return NotFound();

            return Ok(user);
        }


        // add user
        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if(_userService.Post(user) == false)
            {
                return BadRequest();
            }
            return NoContent();
        }


        // delete user
        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if(_userService.Delete(id) == false)
            {
                return BadRequest();
            }
            return NoContent();
        }

    }
}
