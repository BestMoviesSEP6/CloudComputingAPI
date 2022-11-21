using System.Threading.Tasks;

namespace CloudComputingAPI.Services
{
    public interface IUserService
    {
        Task<int> UserAuthentication(string username, string password);
        Task UserSignUp(string username, string password);
    }
}
