using DAL.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.Configurations;

namespace WebAPI.Utils
{
    public class Jwt
    {
        private readonly JwtConfig _jwtConfig;
        public Jwt(JwtConfig jwtConfig)
        {
            _jwtConfig = jwtConfig;
        }
        public string GenerateJwtToken(User user)
        {

            JwtSecurityTokenHandler jwtTokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.UTF8.GetBytes(_jwtConfig.Secret);
            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id" as string, user.Id.ToString()),
                    new Claim("UserName" as string, user.Username.ToString()),
                    new Claim("Role" as string, user.Role.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256)
            };

            SecurityToken securityToken = jwtTokenHandler.CreateToken(securityTokenDescriptor);
            string jwtToken = jwtTokenHandler.WriteToken(securityToken);
            return jwtToken;
        }
    }
}
