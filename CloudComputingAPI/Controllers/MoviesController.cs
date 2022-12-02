using CloudComputingAPI.Models;
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


        // --- Favorites ---


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


        // --- Users' Lists ---


        [EnableCors("AllowOrigin")]
        [HttpPost("list/create/{user_list_name}/{public_list}")]
        public async Task<string> CreateListForUser([FromBody] int user_id, [FromRoute] string user_list_name, [FromRoute] bool public_list)
        {
            return await _moviesService.CreateListForUser(user_id, user_list_name, public_list);
        }

        [EnableCors("AllowOrigin")]
        [HttpPost("list/add/{user_list_id}/{movie_id}")]
        public async Task<string> AddMovieToList([FromBody] int user_id, [FromRoute] int user_list_id, [FromRoute] int movie_id)
        {
            return await _moviesService.AddMovieToList(user_id, user_list_id, movie_id);
        }

        [EnableCors("AllowOrigin")]
        [HttpPost("list/remove/{user_list_id}/{movie_id}")]
        public async Task<string> RemoveMovieFromList([FromBody] int user_id, [FromRoute] int user_list_id, [FromRoute] int movie_id)
        {
            return await _moviesService.RemoveMovieFromList(user_id, user_list_id, movie_id);
        }

        // Returns the content of a list (List of movie_ids)
        [EnableCors("AllowOrigin")]
        [HttpGet("list/content/get/{user_id}/{user_list_id}")]
        public async Task<IEnumerable<int>> GetUserListContent([FromRoute] int user_id, [FromRoute] int user_list_id)
        {
            return await _moviesService.GetUserListContent(user_id, user_list_id);
        }

        // Returns the lists which belongs to a specific user 
        [EnableCors("AllowOrigin")]
        [HttpGet("list/user/get/{user_id}")]
        public async Task<IEnumerable<UserList>> GetAllListsForUser([FromRoute] int user_id)
        {
            return await _moviesService.GetAllListsForUser(user_id);
        }

        [EnableCors("AllowOrigin")]
        [HttpPost("list/edit/{new_user_list_name}/{public_list}")]
        public async Task<string> EditListNameAndPrivacy([FromBody] int user_list_id, [FromRoute] string new_user_list_name, [FromRoute] bool public_list)
        {
            return await _moviesService.EditListNameAndPrivacy(user_list_id, new_user_list_name, public_list);
        }

        // Returns all the public lists except the ones which belongs to the logged in user
        [EnableCors("AllowOrigin")]
        [HttpGet("list/global/get/{user_id}")]
        public async Task<IEnumerable<UserList>> GetAllPublicLists([FromRoute] int user_id)
        {
            return await _moviesService.GetAllPublicLists(user_id);
        }
    }
}
