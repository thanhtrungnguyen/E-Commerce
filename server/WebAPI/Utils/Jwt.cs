using DAL.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebAPI.Utils
{
    public class Jwt
    {
        //private readonly IConfiguration _configuration;

        //public Jwt(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}
        //public string GenerateJwtToken(User user)
        //{

        //    JwtSecurityTokenHandler jwtTokenHandler = new JwtSecurityTokenHandler();
        //    byte[] key = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtConfig:Secret").Value);
        //    SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor()
        //    {
        //        Subject = new ClaimsIdentity(new[]
        //        {
        //            new Claim("Id" as string, user.Id.ToString()),
        //            new Claim("UserName" as string, user.Username.ToString()),
        //            new Claim("Role" as string, user.Role.ToString()),
        //        }),
        //        Expires = DateTime.UtcNow.AddHours(3),
        //        SigningCredentials = new SigningCredentials(
        //            new SymmetricSecurityKey(key),
        //            SecurityAlgorithms.HmacSha256)
        //    };

        //    SecurityToken securityToken = jwtTokenHandler.CreateToken(securityTokenDescriptor);
        //    string jwtToken = jwtTokenHandler.WriteToken(securityToken);
        //    return jwtToken;
        //}
    }
}
