using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Application.System.Auth;
using server.ViewModel.System.Auth;

namespace server.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly IAuthService _AuthService;

        public AuthController(IAuthService authService)
        {
            _AuthService = authService;
        }

        [HttpPost("signin")]
        public async Task<ActionResult> SignIn([FromForm] LoginRequest request)
        {
            var login = await _AuthService.SignIn(request);

            if (login == null)
                return BadRequest("Login failed");

            return Ok(login);
        }

        [HttpPost("refreshtoken")]
        public async Task<ActionResult> RefreshToken([FromForm] LoginRequest request)
        {
            var login = _AuthService.SignIn(request);

            if (login == null)
                return BadRequest("Login failed");

            return Ok(login);
        }
    }
}
