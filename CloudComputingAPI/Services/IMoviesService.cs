using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloudComputingAPI.Services
{
    public interface IMoviesService
    {
        Task<string> AddMovieToFavorites(int user_id, int movie_id);
        Task<string> RemoveMovieFromFavorites(int user_id, int movie_id);
        Task<IEnumerable<int>> GetAllFavorites(int user_id);
    }
}
