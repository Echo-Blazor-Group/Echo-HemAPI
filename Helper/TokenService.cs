using Echo_HemAPI.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Echo_HemAPI.Helper
{
    //Author: Seb
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config; 
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config)
        {
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]!));

        }
        public string CreateToken(Realtor realtor, int realtorFirmId, string? role, string? realtorId)
        {

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, realtor.Email!),
                new Claim(JwtRegisteredClaimNames.GivenName, realtor.Email!),
                new Claim("RealtorFirmId", realtorFirmId.ToString()),
                new Claim("RealtorId",realtorId)
            };

            if (!string.IsNullOrEmpty(role) && !string.IsNullOrWhiteSpace(role))
                claims.Add(new Claim(ClaimTypes.Role, role));

            

            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //Claimsidentity = "Wallet"
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = credentials,
                Issuer = "API",
                Audience = "Client"
            };

            
            var _tokenHandler = new JwtSecurityTokenHandler();
            var token = _tokenHandler.CreateToken(tokenDescriptor);
            return _tokenHandler.WriteToken(token);
            
        }
    }
}
