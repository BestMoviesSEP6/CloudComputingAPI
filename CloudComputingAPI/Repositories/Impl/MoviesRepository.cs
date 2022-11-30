using Dapper;
using System.Collections.Generic;
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
    }
}
