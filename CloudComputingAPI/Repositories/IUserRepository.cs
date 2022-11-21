using CloudComputingAPI.Models;
using System.Threading.Tasks;

namespace CloudComputingAPI.Repositories
{
    public interface IUserRepository
    {
        Task<UserLogin> GetUserLogin(string username);
        Task CreateUser(string username, string password); 
    }
}
