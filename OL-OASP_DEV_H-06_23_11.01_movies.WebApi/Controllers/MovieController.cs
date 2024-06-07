using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using OL_OASP_DEV_H_06_23_11._01_movies.Shared.Models.Binding;
using OL_OASP_DEV_H_06_23_11._01_movies.Shared.Models.ViewModels;
using OL_OASP_DEV_H_06_23_11._01_movies.WebApi.Services.Interfaces;

namespace OL_OASP_DEV_H_06_23_11._01_movies.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMoviesService _moviesService;
        private readonly IValidator<MovieBinding> _movieBindingValidator;
        private readonly IValidator<MovieUpdateBinding> _movieUpdateBindingValidator;

        public MovieController(IMoviesService moviesService, 
            IValidator<MovieBinding> movieBindingValidator, IValidator<MovieUpdateBinding> movieUpdateBindingValidator)
        {
            _moviesService = moviesService;
            _movieBindingValidator = movieBindingValidator;
            _movieUpdateBindingValidator = movieUpdateBindingValidator;
        }



        /// <summary>
        /// Adds a movie to the database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(MovieViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<MovieViewModel>> Add(MovieBinding model)
        {
    
            var result = await _movieBindingValidator.ValidateAsync(model);
            if (result.IsValid)
            {
                var movie = _moviesService.Add(model);
                return Ok(movie);
            }
            return BadRequest(result.ToDictionary());
        }
        /// <summary>
        /// Updates a movie in the database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(MovieViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<MovieViewModel>> Update(MovieUpdateBinding model)
        {
            var result = await _movieUpdateBindingValidator.ValidateAsync(model);
            if (result.IsValid)
            {
                var movie = _moviesService.Update(model);
                return Ok(movie);
            }

            return BadRequest(result.ToDictionary());
        }

        /// <summary>
        /// Gets a movie by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MovieViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<MovieViewModel>> Get(int id)
        {
            var movie = _moviesService.Get(id);
            return Ok(movie);
        }
        /// <summary>
        /// Deletes a movie by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(MovieViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<MovieViewModel>> Delete(int id)
        {
            await _moviesService.Delete(id);
            return Ok(new { Poruka = $"Film sa idom {id} je uspješno obrisan!" });
        }


        /// <summary>
        /// Fetches movies with pagination.
        /// </summary>
        /// <param name="page">The page number.</param>
        /// <param name="pageSize">The number of movies per page.</param>
        /// <returns>A list of MovieViewModel objects.</returns>
        [HttpGet("{page}/{pageSize}")]
        [ProducesResponseType(typeof(List<MovieViewModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<MovieViewModel>>> GetMoviesWithPagination(int page, int pageSize)
        {
            var movie = await _moviesService.GetMoviesWithPagination(page, pageSize);
            return Ok(movie);
        }

        /// <summary>
        /// Get all movies
        /// </summary>
        /// <returns></returns>
        [HttpGet("movies")]
        [ProducesResponseType(typeof(List<MovieViewModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<MovieViewModel>>> GetMovies()
        {
            var movie = await _moviesService.GetMovies();
            return Ok(movie);
        }
    }
}
