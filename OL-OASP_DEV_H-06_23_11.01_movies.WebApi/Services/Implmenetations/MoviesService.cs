using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OL_OASP_DEV_H_06_23_11._01_movies.Shared.Models.Binding;
using OL_OASP_DEV_H_06_23_11._01_movies.Shared.Models.ViewModels;
using OL_OASP_DEV_H_06_23_11._01_movies.WebApi.Context;
using OL_OASP_DEV_H_06_23_11._01_movies.WebApi.Models.Dbo;
using OL_OASP_DEV_H_06_23_11._01_movies.WebApi.Services.InterFaces;

namespace OL_OASP_DEV_H_06_23_11._01_movies.WebApi.Services.Implmenetations
{
    public class MoviesService : IMoviesService
    {
        public readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public MoviesService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        /// <summary>
        /// Adds a movie to the database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MovieViewModel Add(MovieBinding model)
        {
            var dbo = mapper.Map<Movie>(model);
            dbContext.Movies.Add(dbo);
            dbContext.SaveChanges();
            return mapper.Map<MovieViewModel>(dbo);

        }
        /// <summary>
        ///Gets a movie by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MovieViewModel Get(int id)
        {
            var dbo = dbContext.Movies.FirstOrDefault(m => m.Id == id);
            if (dbo == null)
            {
                return null;
            }
            return mapper.Map<MovieViewModel>(dbo);
        }
        /// <summary>
        /// Deletes a movie by its id
        /// </summary>
        /// <param name="id"></param>
        public async Task Delete(int id)
        {
            var dbo = await dbContext.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if (dbo != null)
            {
                dbContext.Movies.Remove(dbo);
                await dbContext.SaveChangesAsync();
            }
        }
        /// <summary>
        /// Fetches movies with pagination.
        /// </summary>
        /// <param name="page">The page number.</param>
        /// <param name="pageSize">The number of movies per page.</param>
        /// <returns>A list of MovieViewModel objects.</returns>
        public async Task<List<MovieViewModel>> GetMoviesWithPagination(int page, int pageSize)
        {
            var movies = await dbContext.Movies
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return mapper.Map<List<MovieViewModel>>(movies);
        }
        /// <summary>
        /// Updates a movie in the database
        /// </summary>
        /// <param name="model">The movie update data</param>
        /// <returns>The updated MovieViewModel</returns>
        public MovieViewModel Update(MovieUpdateBinding model)
        {
            var dbo = dbContext.Movies.FirstOrDefault(m => m.Id == model.Id);
            if (dbo == null)
            {
                return null;
            }
            mapper.Map(model, dbo);
            dbContext.SaveChanges();

            return mapper.Map<MovieViewModel>(dbo);
        }



    }
}
