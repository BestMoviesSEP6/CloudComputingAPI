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


        // --- Favorites ---


        public async Task<string> AddMovieToFavorites(int user_id, int movie_id)
        {
            return await _moviesRepository.AddMovieToFavorites(user_id, movie_id);
        }

        public async Task<IEnumerable<int>> GetAllFavorites(int user_id)
        {
            return await _moviesRepository.GetAllFavorites(user_id);
        }

        public async Task<string> RemoveMovieFromFavorites(int user_id, int movie_id)
        {
            return await _moviesRepository.RemoveMovieFromFavorites(user_id, movie_id);
        }


        // --- Users' Lists


        public async Task<string> CreateListForUser(int user_id, string user_list_name, bool public_list)
        {
            return await _moviesRepository.CreateListForUser(user_id, user_list_name, public_list);
        }

        public async Task<string> AddMovieToList(int user_id, int user_list_id, int movie_id)
        {
            return await _moviesRepository.AddMovieToList(user_id, user_list_id, movie_id);
        }

        public async Task<string> RemoveMovieFromList(int user_id, int user_list_id, int movie_id)
        {
            return await _moviesRepository.AddMovieToList(user_id, user_list_id, movie_id);
        }

        public async Task<IEnumerable<int>> GetUserListContent(int user_id, int user_list_id)
        {
            return await _moviesRepository.GetUserListContent(user_id, user_list_id);
        }

        public async Task<IEnumerable<UserList>> GetAllListsForUser(int user_id)
        {
            return await _moviesRepository.GetAllListsForUser(user_id);
        }

        public async Task<string> EditListNameAndPrivacy(int user_list_id, string new_user_list_name, bool public_list)
        {
            return await _moviesRepository.EditListNameAndPrivacy(user_list_id, new_user_list_name, public_list);
        }

        public async Task<IEnumerable<UserList>> GetAllPublicLists(int user_id)
        {
            return await _moviesRepository.GetAllPublicLists(user_id);
        }
    }
}
