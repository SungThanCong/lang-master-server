using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using server.Uilities.Constants;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace server.Application.Common
{
    public class JwtService
    {
        private IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Generate(Claim[] claims)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
            var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
            var header = new JwtHeader(credentials);

            var payload = new JwtPayload(_configuration["Tokens:Issuer"],
                _configuration["Tokens:Audience"],
                claims,
                null,
                DateTime.Today.AddHours(SystemConstants.ACCESS_TOKEN_EXPIRED_HOURS));

            var securityToken = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }


        public ClaimsPrincipal Verify(string jwt)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Tokens:Key"]);

            ClaimsPrincipal principal  =  tokenHandler.ValidateToken(jwt, new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,
                ValidIssuer = _configuration["Tokens:Key"],
                ValidAudience = _configuration["Tokens:Key"]
            }, out SecurityToken validatedToken);


            return principal;
        }


        public string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }


        public ClaimsPrincipal GetPrincipalFromExpiredToken(string jwt)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Tokens:Key"]);

            ClaimsPrincipal principal = tokenHandler.ValidateToken(jwt, new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,
                ValidateLifetime = false,
                ValidIssuer = _configuration["Tokens:Key"],
                ValidAudience = _configuration["Tokens:Key"]
            }, out SecurityToken validatedToken) ;


            return principal;
        }
    }
}
