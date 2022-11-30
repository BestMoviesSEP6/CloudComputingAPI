using CloudComputingAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloudComputingAPI.Services.Impl
{
    public class MoviesService : IMoviesService
    {
        private IMoviesRepository _moviesRepository;

        public MoviesService(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        public async Task<string> AddMovieToFavorites(int user_id, int movie_id)
        {
            return await _moviesRepository.AddMovieToFavorites(user_id, movie_id);
        }

        public async Task<IEnumerable<int>> GetAllFavorites(int user_id)
        {
            return await _moviesRepository.GetAllFavorites(user_id);
        }

        public async Task<string> RemoveMovieFromFavorites(int user_id, int movie_id)
        {
            return await _moviesRepository.RemoveMovieFromFavorites(user_id, movie_id);
        }
    }
}
