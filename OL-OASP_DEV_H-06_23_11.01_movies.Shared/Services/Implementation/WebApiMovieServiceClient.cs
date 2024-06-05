using OL_OASP_DEV_H_06_23_11._01_movies.Shared.Models.Binding;
using OL_OASP_DEV_H_06_23_11._01_movies.Shared.Models.ViewModels;
using OL_OASP_DEV_H_06_23_11._01_movies.Shared.Services.Interfaces;

namespace OL_OASP_DEV_H_06_23_11._01_movies.Shared.Services.Implementation
{
    public class WebApiMovieServiceClient : WebApiServiceClientBase, IWebApiServiceClient
    {
        public WebApiMovieServiceClient(HttpClient httpClient, Action<HttpResponseMessage> unsuccessfulResponseAction) : base(httpClient, unsuccessfulResponseAction)
        {
        }
        /// <summary>
        /// Gets a movie by its id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="unsuccessfulResponseAction"></param>
        /// <returns></returns>
        public MovieViewModel GetMovie(long id, Action<HttpResponseMessage> unsuccessfulResponseAction = null)
        {
            return DoRequestAndTryGetResponseContent<MovieViewModel>($"api/movie/{id}", HttpMethod.Get, true, unsuccessfulResponseAction);
        }

        /// <summary>
        /// Gets a movie by its id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="unsuccessfulResponseAction"></param>
        /// <returns></returns>
        public T GetMovie<T>(long id, Action<HttpResponseMessage> unsuccessfulResponseAction = null)
        {
            return DoRequestAndTryGetResponseContent<T>($"api/movie/{id}", HttpMethod.Get, true, unsuccessfulResponseAction);
        }

        /// <summary>
        /// Adds a movie to the database
        /// </summary>
        /// <param name="model"></param>
        /// <param name="unsuccessfulResponseAction"></param>
        /// <returns></returns>
        public MovieViewModel AddMovie(MovieBinding model, Action<HttpResponseMessage> unsuccessfulResponseAction = null)
        {
            return DoRequestAndTryGetResponseContent<MovieViewModel>("api/movie", HttpMethod.Post, true, unsuccessfulResponseAction, model);
        }

        /// <summary>
        /// Updates a movie in the database
        /// </summary>
        /// <param name="model"></param>
        /// <param name="unsuccessfulResponseAction"></param>
        /// <returns></returns>
        public MovieViewModel Update(MovieUpdateBinding model, Action<HttpResponseMessage> unsuccessfulResponseAction = null)
        {
            return DoRequestAndTryGetResponseContent<MovieViewModel>("api/movie", HttpMethod.Put, true, unsuccessfulResponseAction, model);
        }


        /// <summary>
        ///  Get all movies
        /// </summary>
        /// <param name="unsuccessfulResponseAction"></param>
        /// <returns></returns>
        public List<MovieViewModel> GetMovies(Action<HttpResponseMessage> unsuccessfulResponseAction = null)
        {
            return DoRequestAndTryGetResponseContent<List<MovieViewModel>>($"api/movie/movies", HttpMethod.Get, true, unsuccessfulResponseAction);
        }

    }
}
