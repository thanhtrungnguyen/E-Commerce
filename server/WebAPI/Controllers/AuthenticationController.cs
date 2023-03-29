using BLL.Abstractions;
using BLL.Services;
using DTO.CategoryDTO.Create;
using DTO.UserDTO.Registration;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Configurations;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtConfig _jwtConfig;

        public AuthenticationController(IUserService userService, JwtConfig jwtConfig)
        {
            _userService = userService;
            _jwtConfig = jwtConfig;
        }

        [HttpPost]
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

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserRegistrationRequest userRegistration)
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
    }
}
