using BLL.Abstractions;
using BLL.Services;
using DAL.Abstractions;
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

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenRepository _tokenRepository;

        public AuthenticationController(IUserService userService, ITokenRepository tokenRepository)
        {
            _userService = userService;
            _tokenRepository = tokenRepository;
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
                string token = _tokenRepository.CreateJwtToken(user);
                return Ok(new { user = user, jwtToken = token });
            }
            return NotFound("Username or Password is wrong!");

        }

        [HttpPost("/refreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] UserLoginRequest loginRequest)
        {
            return BadRequest();
        }
    }
}
