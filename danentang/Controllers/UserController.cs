using danentang.Dtos;
using danentang.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace danentang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] CreateUserDto input)
        {
            var user = _userService.CreateUser(input);
            return Ok(user);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginDto input)
        {
            var login = await _userService.LoginAsync(input);
            return Ok(login);
        }
        [HttpPut("update_user")]
        public IActionResult UpdateUser([FromBody] UpdateUserDto input)
        {
            try
            {
                _userService.UpdateUser(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
