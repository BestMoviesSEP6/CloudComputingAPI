using CloudComputingAPI.Models;
using CloudComputingAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloudComputingAPI.Services
{
    public class MoviesService : IMoviesService
    {
        private IMoviesRepository _moviesRepository;

        public MoviesService(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }
        public async Task<IEnumerable<Movie>> GetMovies()
        {
            return await _moviesRepository.GetMovieById();
        }
    }
}
