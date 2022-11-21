using CloudComputingAPI.Models;
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

        public async Task AddMovieToFavorites(int user_id, int movie_id)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = @"INSERT INTO [dbo].[favorites] (movie_id, user_id)
                                VALUES (@movie_id, @user_id)";
                await connection.ExecuteAsync(query, new { movie_id = movie_id, user_id = user_id }).ConfigureAwait(false);
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
    }
}
