using CloudComputingAPI.Models;
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

        public async Task AddMovieToFavorites(int user_id, int movie_id)
        {
            await _moviesRepository.AddMovieToFavorites(user_id, movie_id);
        }

        public async Task<IEnumerable<int>> GetAllFavorites(int user_id)
        {
            return await _moviesRepository.GetAllFavorites(user_id);
        }
    }
}
