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

        public async Task<IEnumerable<Movie>> GetRecommendedMovies()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "SELECT TOP(1000) id, title, year FROM [dbo].[movies]";
                var movie = await connection.QueryAsync<Movie>(query);
                return movie;
            }
        }

        public async Task<Movie> GetMovieById(int movieId)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = @"";
                var movie = await connection.QuerySingleOrDefaultAsync<Movie>(query);
                return movie;
            }
        }
    }
}
