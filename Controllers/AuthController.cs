using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskFlowAPI.DTOs;
using TaskFlowAPI.Services;

namespace TaskFlowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(LoginRequestDto user)
        {
            string token = _authService.Login(user);
            return Ok(new { token });
        }
    }
}
