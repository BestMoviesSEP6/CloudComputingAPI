using CloudComputingAPI.Models;
using Dapper;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CloudComputingAPI.Repositories.Impl
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly DapperDbContext _context;

        public MoviesRepository(DapperDbContext context)
        {
            _context = context;
        }

        public MoviesRepository()
        {
        }


        // --- Favorites ---


        public async Task<string> AddMovieToFavorites(int user_id, int movie_id)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = @"IF NOT EXISTS ( SELECT 1 FROM [dbo].[favorites] WHERE movie_id = @movie_id AND user_id = @user_id )
                                    BEGIN
                                        INSERT INTO [dbo].[favorites] (movie_id, user_id)
                                            VALUES (@movie_id, @user_id)
                                    END";
                var amountOfAffectedRows = await connection.ExecuteAsync(query, new { movie_id = movie_id, user_id = user_id }).ConfigureAwait(false);
                if (amountOfAffectedRows > 0)
                {
                    return "Success";
                }
                else
                {
                    return "Movie is already added";
                }
            }
        }

        public async Task<IEnumerable<int>> GetAllFavorites(int user_id)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = @"SELECT movie_id 
                                FROM [dbo].[favorites] 
                                WHERE user_id = @user_id";
                var movie = await connection.QueryAsync<int>(query, new { user_id = user_id }).ConfigureAwait(false);
                return movie;
            }
        }

        public async Task<string> RemoveMovieFromFavorites(int user_id, int movie_id)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = @"DELETE FROM [dbo].[favorites] 
                                WHERE user_id = @user_id AND movie_id = @movie_id";
                var amountOfAffectedRows = await connection.ExecuteAsync(query, new { movie_id = movie_id, user_id = user_id }).ConfigureAwait(false);
                if (amountOfAffectedRows > 0)
                {
                    return "Success";
                }
                else
                {
                    return "The movie is not in the favorites list in order to be removed";
                }
            }
        }


        // --- Users' Lists ---


        public async Task<string> CreateListForUser(int user_id, string user_list_name, bool public_list)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = @"INSERT INTO [dbo].[usersLists] (user_id, list_name, public_list)
                                VALUES(@user_id, @list_name, @public_list)";

                var amountOfAffectedRows = await connection.ExecuteAsync(query,
                    new { user_id = user_id, list_name = user_list_name, public_list = public_list }).ConfigureAwait(false);

                if (amountOfAffectedRows > 0)
                {
                    return "Success";
                }
                else
                {
                    return "Insertion of the list in the database failed";
                }
            }
        }

        public async Task<string> AddMovieToList(int user_id, int user_list_id, int movie_id)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = @"INSERT INTO [dbo].[moviesInLists]
                                VALUES (@list_id, @movie_id)";

                    var amountOfAffectedRows = await connection.ExecuteAsync(query,
                        new { list_id = user_list_id, movie_id = movie_id }).ConfigureAwait(false);

                    if (amountOfAffectedRows > 0)
                    {
                        return "Success";
                    }
                    else
                    {
                        return "Movie couldn't be added, most probably is already there";
                    }
                }
            }
            catch (SqlException e)
            {
                return "Movie couldn't be added, most probably is already there";
            }
        }

        public async Task<string> RemoveMovieFromList(int user_id, int user_list_id, int movie_id)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var query = @"DELETE FROM [dbo].[moviesInLists]
                                WHERE list_id = @list_id and movie_id = @movie_id";

                    var amountOfAffectedRows = await connection.ExecuteAsync(query,
                        new { list_id = user_list_id, movie_id = movie_id }).ConfigureAwait(false);

                    if (amountOfAffectedRows > 0)
                    {
                        return "Success";
                    }
                    else
                    {
                        return "Movie couldn't be removed, most probably is not there";
                    }
                }
            }
            catch (SqlException e)
            {
                return "Movie couldn't be removed, most probably is not there";
            }
        }

        public async Task<IEnumerable<int>> GetUserListContent(int user_id, int user_list_id)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = @"SELECT movie_id FROM [dbo].[moviesInLists]
                                WHERE list_id = @list_id";

                var result = await connection.QueryAsync<int>(query,
                    new { list_id = user_list_id }).ConfigureAwait(false);

                return result;
            }
        }

        public async Task<IEnumerable<UserList>> GetAllListsForUser(int user_id)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = @"SELECT list_id, list_name FROM [dbo].[usersLists] WHERE user_id = @user_id";

                var result = await connection.QueryAsync<UserList>(query,
                    new { user_id = user_id }).ConfigureAwait(false);

                return result;
            }
        }

        public async Task<string> EditListNameAndPrivacy(int user_list_id, string new_user_list_name, bool public_list)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = @"UPDATE [dbo].[usersLists]
                                SET list_name = @list_name, public_list = @public_list
                                WHERE list_id = @list_id";

                var amountOfAffectedRows = await connection.ExecuteAsync(query,
                    new { list_name = new_user_list_name, list_id = user_list_id, public_list = public_list }).ConfigureAwait(false);

                if (amountOfAffectedRows > 0)
                {
                    return "Success";
                }
                else
                {
                    return "List couldn't be moified";
                }
            }
        }

        public async Task<IEnumerable<UserList>> GetAllPublicLists(int user_id)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = @"SELECT list_id, list_name
                                FROM [dbo].[usersLists]
                                WHERE public_list = 1 and user_id != @user_id";

                var result = await connection.QueryAsync<UserList>(query,
                    new { user_id = user_id }).ConfigureAwait(false);

                return result;
            }
        }
    }
}
