using OL_OASP_DEV_H_06_23_11._01_movies.Shared.Models.ViewModels;
using OL_OASP_DEV_H_06_23_11._01_movies.Shared.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OL_OASP_DEV_H_06_23_11._01_movies.Shared.Services.Implementation
{
    public class WebApiMovieServiceClient : WebApiServiceClientBase, IWebApiServiceClient
    {
        public WebApiMovieServiceClient(HttpClient httpClient, Action<HttpResponseMessage> unsuccessfulResponseAction) : base(httpClient, unsuccessfulResponseAction)
        {
        }

        public MovieViewModel GetMovie(long id, Action<HttpResponseMessage> unsuccessfulResponseAction = null)
        {
            return DoRequestAndTryGetResponseContent<MovieViewModel>($"api/movie/{id}", HttpMethod.Get, true, unsuccessfulResponseAction);
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
