using Microsoft.AspNetCore.Mvc;
using backend.Services;
using backend.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public ActionResult<LoginResponse> Login([FromBodyBody] LoginRequest request)
        {
            var token = _authService.ValidateCredentials(request.Password);
            if (token == null)
            {
                return Unauthorized(new { message = "Senha Invalida"});
            }
            
            return Ok(new LoginResponse
            {
                Token = token,
                ExpiresAt = DateTime.UtcNow.AddHours(8)
            });
        }
        [HttpGet("validate")]
        public ActionResult ValidateToken()
        {
            return Ok(new {valid = true, message = "Token is valid" });
        }
    }
}