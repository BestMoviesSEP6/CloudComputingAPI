using CloudComputingAPI.Services;
using CloudComputingAPI.Services.Impl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CloudComputingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        private IUserService _userService;

        public UserController(ILogger<MoviesController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet("login/{username}/{password}")]
        public async Task<int> UserAuthentication([FromRoute] string username, [FromRoute] string password)
        {
            return await _userService.UserAuthentication(username, password);
        }

        [HttpPost("create/{username}/{password}")]
        public async Task UserSignUp([FromRoute] string username, [FromRoute] string password)
        {
            await _userService.UserSignUp(username, password);
        }
    }
}
