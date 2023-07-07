using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using server.Application.System.Auth;
using server.Data.EF;
using server.ViewModel.System.Auth;
using System.Net.Mail;
using System.Net;
using server.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace server.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly IAuthService _AuthService;
        public readonly LangDbContext _context;
        public readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;


        public AuthController(IAuthService authService, LangDbContext context, UserManager<AppUser>userManager, IConfiguration configuration)
        {
            _AuthService = authService;
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost("signin")]
        public async Task<ActionResult> SignIn([FromBody] LoginRequest request)
        {
            var login = await _AuthService.SignIn(request);

            if (login == null)
                return BadRequest("Login failed");

            return Ok(login);
        }

        [HttpPost("refreshtoken")]
        public async Task<ActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            if (request == null)
            {
                var response = new { message = "Refresh Token is required!" };
                return StatusCode(403, response);
            }
            try
            {
                var refreshToken = _context.RefreshTokens.Where(x => x.Token == request.RefreshToken).FirstOrDefault();
                if (refreshToken == null) return StatusCode(403, new { message = "Refresh token is not in database!" });

                var accessToken = _AuthService.RefreshToken(refreshToken);

                if (accessToken == null)
                    return BadRequest("Refresh token was expired. Please make a new signin request");

                return Ok(new {accessToken=accessToken, refreshToken = refreshToken.Token});
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost("send-mail")] 
        public async Task<IActionResult> SendEmail([FromBody] SendEmailRequest request)
        {
            var isExistUser = await _userManager.FindByNameAsync(request.Username);
            if (isExistUser == null)
            {
                return BadRequest("User doesn't exist!");
            }

            var email = isExistUser.Email;
            var confirmCode = await _AuthService.CreateConfirmCode(isExistUser);
            var htmlBody = $"<div style=\"padding: 10px; background-color: #003375\">\r\n          " +
                $"<div style=\"padding: 10px; background-color: white;\">\r\n              " +
                $"<h4 style=\"color: #0085ff\">Hi {isExistUser.UserName}</h4>\r\n              " +
                $"<span style=\"color: black\">Your confirm code is {confirmCode}</span>\r\n          " +
                $"</div>\r\n      </div>";


            var message = new MailMessage();
            message.To.Add(new MailAddress(email));
            message.Subject = "Reset Password";
            message.Body = htmlBody;
            message.IsBodyHtml = true;
            
            
            using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential
                {
                    UserName = _configuration["Email:GOOGLE_ACCOUNT"],
                    Password = _configuration["Email:GOOGLE_PASSWORD"]
                };
                smtpClient.EnableSsl = true;
                await smtpClient.SendMailAsync(message);
            }

            return Ok($"Send confirm code to {email} successfully");
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            var username = request.Username;
            var isExistUser = await _userManager.FindByNameAsync(username);
            var code = request.Code;
            var confirmCode = await _context.ConfirmCodes.FirstOrDefaultAsync(c => c.IdUser == isExistUser.Id && c.Token == code);

            if (confirmCode == null)
            {
                return NotFound(new { message = "Confirm code is incorrect!" });
            }
            var resultResetPassword = await _AuthService.ResetPassword(confirmCode, isExistUser, request.Password);
            if (resultResetPassword == -1)
            {
                return StatusCode(404, new { message = "Confirm code was expired. Please make a new reset request" });
            }
            else if (resultResetPassword == 0)
            {
                return StatusCode(500, new { message = "Reset password failure" });

            }
            return Ok(new { message = "Reset password successfully." });
        }

    }
}
