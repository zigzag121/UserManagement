using Microsoft.AspNetCore.Mvc;
using UserManagement.Data.Entities;
using UserManagement.Services.Interfaces;

namespace UserManagement.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserByID(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User user)
        {
            if (id != user.UserID)
            {
                return BadRequest();
            }

            var result = _userService.UpdateUser(id, user);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return NoContent();
        }
    }
}
