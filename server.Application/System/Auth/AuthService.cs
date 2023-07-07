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

        public async Task<string> RefreshToken(RefreshTokens requestToken)
        {
            try
            {
                if (requestToken.ExpiryDate.CompareTo(DateTime.Now) < 0) return null;

                Claim[] claims = new[]
                {
                    new Claim("id", requestToken.AppUser.Id.ToString())
                };
                var newAccessToken = _JwtService.Generate(claims);

                return newAccessToken;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
            
        }

        public async Task<int> ResetPassword(ConfirmCodes code, AppUser user, string newPassword)
        {
            if (code.ExpiryDate.Date < new DateTime().Date)
            {
                _context.ConfirmCodes.Remove(code);
                await _context.SaveChangesAsync();
                return -1;
            }
            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result =await _userManager.ResetPasswordAsync(user, resetToken, newPassword );

            return result == IdentityResult.Success ? 1 : 0;             

        }

        public async Task<string> CreateConfirmCode(AppUser user)
        {
            var expiredAt = DateTime.Now;

            expiredAt.AddSeconds(120);
            var _token = Math.Floor(new Random().Next(900000) + 100000 * 1.0);
            var confirmCode = _context.ConfirmCodes.Add(new ConfirmCodes() {
                Token = _token.ToString(),
                IdUser = user.Id,
                ExpiryDate = expiredAt,
            });
            var result = await _context.SaveChangesAsync();
            if (result > 0)
                return _token.ToString();
            else return null;
        }


        public async Task<object> SignIn(LoginRequest request)
        {

            //var account = await _userManager.FindByNameAsync(request.Username);
            var account = await _context.AppUsers.Where(x => x.UserName == request.Username).FirstOrDefaultAsync();

            if (account == null) return null;

            var checkLogin = await _userManager.CheckPasswordAsync(account, request.Password);
            if (checkLogin == false) return null;

            var role = (await _userManager.GetRolesAsync(account))[0];

            Claim[] claims = new[]
            {
                new Claim("id", account.Id.ToString()),
                new Claim(ClaimTypes.Name, account.UserName),
                new Claim(ClaimTypes.Role, role)
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
            //var role = _userManager.GetRolesAsync(account);
            //------------------

            return new { user = new { account.DisplayName, account.UserName, account.PhoneNumber, account.Address, idUser = account.Id, Role = new {name = role },
                idLecture=account.Lecturer?.IdLecturer, idEmployee=account.Employee?.IdEmployee  }
            , accessToken = accessToken, refreshToken = refreshToken_token };

        }
    }
}
