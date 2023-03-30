using BLL.Abstractions;
using BLL.Services;
using DAL.Entities;
using DTO.CategoryDTO.Create;
using DTO.UserDTO.Login;
using DTO.UserDTO.Registration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.Configurations;
using WebAPI.Utils;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AuthenticationController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("/register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest userRegistration)
        {
            bool isExistEmail = await _userService.CheckExistEmail(userRegistration.Email);
            if (isExistEmail)
            {
                return BadRequest();
            }
            bool isExistPhone = await _userService.CheckExistPhone(userRegistration.Phone);
            if (isExistPhone)
            {
                return BadRequest();
            }
            var result = await _userService.AddUser(userRegistration);
            if (result.IsError)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result.ErrorMessage);
            }
            return Ok();
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest loginRequest)
        {
            User user = await _userService.CheckExistUsernameAndPassword(loginRequest.Username, loginRequest.Password);
            if (user is not null)
            {
                string token = GenerateJwtToken(user);
                return Ok(token);
            }
            return NotFound("Username or Password is wrong!");

        }

        private string GenerateJwtToken(User user)
        {

            JwtSecurityTokenHandler jwtTokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtConfig:Secret").Value);
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
