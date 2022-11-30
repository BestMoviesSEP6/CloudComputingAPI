using CloudComputingAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloudComputingAPI.Services
{
    public interface IMoviesService
    {
        // --- Favorites ---

        Task<string> AddMovieToFavorites(int user_id, int movie_id);
        Task<string> RemoveMovieFromFavorites(int user_id, int movie_id);
        Task<IEnumerable<int>> GetAllFavorites(int user_id);

        // --- Users' Lists ---

        Task<string> CreateListForUser(int user_id, string user_list_name, bool public_list);
        Task<string> AddMovieToList(int user_id, int user_list_id, int movie_id);
        Task<string> RemoveMovieFromList(int user_id, int user_list_id, int movie_id);
        Task<IEnumerable<int>> GetUserListContent(int user_id, int user_list_id);
        Task<IEnumerable<UserList>> GetAllListsForUser(int user_id);
        Task<string> EditListNameAndPrivacy(int user_list_id, string new_user_list_name, bool public_list);
        Task<IEnumerable<UserList>> GetAllPublicLists(int user_id);
    }
}
