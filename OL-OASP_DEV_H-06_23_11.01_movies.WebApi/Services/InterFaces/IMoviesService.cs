using OL_OASP_DEV_H_06_23_11._01_movies.Shared.Models.Binding;
using OL_OASP_DEV_H_06_23_11._01_movies.Shared.Models.ViewModels;

namespace OL_OASP_DEV_H_06_23_11._01_movies.WebApi.Services.Interfaces
{
    public interface IMoviesService
    {
        /// <summary>
        /// Deletes a movie by its id
        /// </summary>
        /// <param name="id"></param>
        Task Delete(int id);
        /// <summary>
        /// Fetches movies with pagination.
        /// </summary>
        /// <param name="page">The page number.</param>
        /// <param name="pageSize">The number of movies per page.</param>
        /// <returns>A list of MovieViewModel objects.</returns>
        Task<List<MovieViewModel>> GetMoviesWithPagination(int page, int pageSize);
        /// <summary>
        ///Gets a movie by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        MovieViewModel Get(int id);
        MovieViewModel Update(MovieUpdateBinding model);
        /// <summary>
        /// Adds a movie to the database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        MovieViewModel Add(MovieBinding model);
        /// <summary>
        /// Get all movies
        /// </summary>
        /// <returns></returns>
        Task<List<MovieViewModel>> GetMovies();
    }
}