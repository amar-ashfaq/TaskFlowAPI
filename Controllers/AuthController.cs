using Microsoft.AspNetCore.Mvc;
using TaskFlowAPI.Entities;
using TaskFlowAPI.Services;

namespace TaskFlowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IPasswordService _passwordService;
        public AuthController(IAuthService authService, IPasswordService passwordService)
        {
            _authService = authService;
            _passwordService = passwordService;
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            return Ok();
        }
    }
}
