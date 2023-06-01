using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using server.Application.Common;
using server.Data.EF;
using server.Data.Entities;
using server.ViewModel.System.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.System.Auth
{
    public class AuthService : IAuthService
    {
        public readonly UserManager<AppUser> _userManager;
        public readonly RoleManager<AppRole> _roleManager;
        public readonly SignInManager<AppUser> _signInManager;
        private readonly LangDbContext _context;
        private readonly JwtService _JwtService;


        public AuthService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, 
            SignInManager<AppUser> signInManager, LangDbContext context, JwtService jwtService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;
            _JwtService = jwtService;
        }

        public async Task<string> RefreshToken(string requestToken)
        {
            var tokenExist = await _context.RefreshTokens.Where(x => x.Token == requestToken).FirstOrDefaultAsync();
            if (tokenExist == null) return null;
            if (tokenExist.ExpiryDate.CompareTo(DateTime.Now) < 0) return null;

            Claim[] claims = new[]
            {
                new Claim("id", tokenExist.AppUser.Id.ToString())
            };
            var newAccessToken = _JwtService.Generate(claims);

            return newAccessToken;
            
        }

        public async Task<string> ResetPassword()
        {
            throw new NotImplementedException();
        }

        public async Task<string> SendEmail(SendEmailRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<object> SignIn(LoginRequest request)
        {
          
            var account = await _userManager.FindByNameAsync(request.Username);
            if (account == null) return null;

            var checkLogin = await _userManager.CheckPasswordAsync(account, request.Password);
            if (checkLogin == false) return null;

            Claim[] claims = new[]
            {
                new Claim("id", account.Id.ToString())
            };
            var accessToken = _JwtService.Generate(claims);
            var refreshToken_token = _JwtService.GenerateRefreshToken();

            //Create new refreshtoken
            var checkRefreshTokenExist = _context.RefreshTokens.Where(x => x.IdUser == account.Id).FirstOrDefault();
            if (checkRefreshTokenExist != null)
            {
                checkRefreshTokenExist.Token = refreshToken_token;
                checkRefreshTokenExist.UpdateAt = DateTime.Now;
                checkRefreshTokenExist.ExpiryDate = DateTime.Now.AddDays(7);
            }
            else
            {
                var refreshToken = new RefreshTokens()
                {
                    Token = refreshToken_token,
                    UpdateAt = DateTime.Now,
                    IdUser = account.Id,
                    ExpiryDate = DateTime.Now.AddDays(7)
                };

                await _context.RefreshTokens.AddAsync(refreshToken);
            }
            await _context.SaveChangesAsync();
            //------------------

            return new { accessToken = accessToken, refreshToken = refreshToken_token };

        }
    }
}
