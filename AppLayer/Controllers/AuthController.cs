using BLL.Interfaces;
using DAL.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppLayer.Controllers
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
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            var token = await _authService.AuthenticateAsync(login.username, login.password);
            if(string.IsNullOrEmpty(token))
            {
                return Unauthorized("Invalid credentials");
            }
            return Ok(new { Token = token});
        }
    }
}
