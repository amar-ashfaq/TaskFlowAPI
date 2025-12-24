using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskFlowAPI.DTOs;

namespace TaskFlowAPI.Services
{
    public class TokenService : ITokenService
    {   
        private readonly IConfiguration _config;

        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateJwtToken(UserReadDto user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var jwtSection = _config.GetSection("Jwt");

            if (jwtSection == null)
            {
                throw new InvalidOperationException("Could not fetch Jwt details");
            }

            var secretKey = jwtSection.GetValue<string>("SecretKey");
            var audience = jwtSection.GetValue<string>("Audience");
            var issuer = jwtSection.GetValue<string>("Issuer");
            var expiresInMinutes = jwtSection.GetValue<int>("ExpiresInMinutes");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var jwtToken = new JwtSecurityToken(
                issuer = issuer,
                audience = audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(expiresInMinutes),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
