using Microsoft.AspNetCore.Mvc;
using TaskFlowAPI.DTOs;
using TaskFlowAPI.Services;

namespace TaskFlowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<UserReadDto> GetUsers()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<UserReadDto> GetUser(int id)
        {
            var user = _userService.GetUser(id);
            return Ok(user);
        }

        [HttpGet("username/{username}")]
        public ActionResult<TaskReadDto> GetUserByUsername(string username)
        {
            var user = _userService.GetUserByUsername(username);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser(UserCreateDto userDto)
        {
            var created = _userService.CreateUser(userDto);
            return CreatedAtAction(nameof(GetUser), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, UserUpdateDto userDto)
        {
            _userService.UpdateUser(id, userDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return NoContent();
        }
    }
}
