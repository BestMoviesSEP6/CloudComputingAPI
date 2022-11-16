using CloudComputingAPI.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloudComputingAPI.Repositories
{
    public interface IMoviesRepository
    {
        public Task<IEnumerable<Movie>> GetRecommendedMovies();
        Task<Movie> GetMovieById(int movieId);
    }
}
