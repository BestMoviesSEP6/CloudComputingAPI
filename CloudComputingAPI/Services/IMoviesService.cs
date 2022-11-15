using CloudComputingAPI.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloudComputingAPI.Services
{
    public interface IMoviesService
    {
        Task<IEnumerable<Movie>> GetMovies();
    }
}
