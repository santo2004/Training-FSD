using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Authentication_Prac.Models;
using Authentication_Prac.Repositories;

namespace Authentication_Prac.Controllers
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

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var result = await _authService.RegisterAsync(model);
            if (result.Contains("success"))
                return Ok(new { Message = result });

            return BadRequest(new { Error = result });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var result = await _authService.LoginAsync(model);
            if (result == null)
                return Unauthorized(new { Error = "Invalid credentials." });

            return Ok(result);
        }
    }
}
