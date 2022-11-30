using CloudComputingAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloudComputingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        private IMoviesService _moviesService;

        public MoviesController(ILogger<MoviesController> logger, IMoviesService moviesService)
        {
            _logger = logger;
            _moviesService = moviesService;
        }

        [EnableCors("AllowOrigin")]
        [HttpPost("favorites/add/{user_id}/{movie_id}")]
        public async Task<string> AddMovieToFavorites([FromRoute] int user_id, [FromRoute] int movie_id)
        {
            return await _moviesService.AddMovieToFavorites(user_id, movie_id);
        }

        [EnableCors("AllowOrigin")]
        [HttpPost("favorites/remove/{user_id}/{movie_id}")]
        public async Task<string> RemoveMovieFromFavorites([FromRoute] int user_id, [FromRoute] int movie_id)
        {
            return await _moviesService.RemoveMovieFromFavorites(user_id, movie_id);
        }

        [EnableCors("AllowOrigin")]
        [HttpGet("favorites/get/{user_id}")]
        public async Task<IEnumerable<int>> GetFavorites([FromRoute] int user_id)
        {
            return await _moviesService.GetAllFavorites(user_id);
        }

        [EnableCors("AllowOrigin")]
        [HttpPost("personalList/create/{listName}/{endReleaseDate}")]
        public async Task<string>
    }
}
