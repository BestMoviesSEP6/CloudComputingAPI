using System.Threading.Tasks;

namespace CloudComputingAPI.Repositories
{
    public interface ITMDbRepository
    {
        Task GetMovieById(int deviceId);
    }
}
