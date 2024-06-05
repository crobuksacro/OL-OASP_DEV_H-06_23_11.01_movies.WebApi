using OL_OASP_DEV_H_06_23_11._01_movies.Shared.Models.ViewModels;

namespace OL_OASP_DEV_H_06_23_11._01_movies.Shared.Services.Interfaces
{
    public interface IWebApiServiceClient
    {
        MovieViewModel GetMovie(long id, Action<HttpResponseMessage> unsuccessfulResponseAction = null);
        List<MovieViewModel> GetMovies(Action<HttpResponseMessage> unsuccessfulResponseAction = null);
    }
}