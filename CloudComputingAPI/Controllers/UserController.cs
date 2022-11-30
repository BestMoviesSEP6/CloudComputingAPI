using CloudComputingAPI.Services;
using Microsoft.AspNetCore.Cors;
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

        [EnableCors("AllowOrigin")]
        [HttpPost("login/{username}")]
        public async Task<int> UserAuthentication([FromRoute] string username, [FromBody] string password)
        {
            return await _userService.UserAuthentication(username, password);
        }

        [EnableCors("AllowOrigin")]
        [HttpPost("create/{username}")]
        public async Task<string> UserSignUp([FromRoute] string username, [FromBody] string password)
        {
            return await _userService.UserSignUp(username, password);
        }
    }
}
