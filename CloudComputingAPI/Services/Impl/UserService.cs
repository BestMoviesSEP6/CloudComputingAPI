using CloudComputingAPI.Repositories;
using System.Threading.Tasks;

namespace CloudComputingAPI.Services.Impl
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> UserAuthentication(string username, string password)
        {
            var userLogin = await _userRepository.GetUserLogin(username);
            if(userLogin.password == password)
            {
                return userLogin.user_id;
            }
            return 0;
        }

        public async Task UserSignUp(string username, string password)
        {
            await _userRepository.CreateUser(username, password);
        }
    }
}
