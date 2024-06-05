using OL_OASP_DEV_H_06_23_11._01_movies.Shared.Models.Binding;
using OL_OASP_DEV_H_06_23_11._01_movies.Shared.Models.ViewModels;

namespace OL_OASP_DEV_H_06_23_11._01_movies.Shared.Services.Interfaces
{
    public interface IWebApiServiceClient
    {
        /// <summary>
        /// Adds a movie to the database
        /// </summary>
        /// <param name="model"></param>
        /// <param name="unsuccessfulResponseAction"></param>
        /// <returns></returns>
        MovieViewModel AddMovie(MovieBinding model, Action<HttpResponseMessage> unsuccessfulResponseAction = null);
        /// <summary>
        /// Updates a movie in the database
        /// </summary>
        /// <param name="model"></param>
        /// <param name="unsuccessfulResponseAction"></param>
        /// <returns></returns>
        MovieViewModel Update(MovieUpdateBinding model, Action<HttpResponseMessage> unsuccessfulResponseAction = null);
        MovieViewModel GetMovie(long id, Action<HttpResponseMessage> unsuccessfulResponseAction = null);
        List<MovieViewModel> GetMovies(Action<HttpResponseMessage> unsuccessfulResponseAction = null);
    }
}