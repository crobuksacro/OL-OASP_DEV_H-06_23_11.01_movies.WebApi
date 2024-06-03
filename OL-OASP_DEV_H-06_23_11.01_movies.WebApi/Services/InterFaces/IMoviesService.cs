using OL_OASP_DEV_H_06_23_11._01_movies.Shared.Models.Binding;
using OL_OASP_DEV_H_06_23_11._01_movies.Shared.Models.ViewModels;

namespace OL_OASP_DEV_H_06_23_11._01_movies.WebApi.Services.InterFaces
{
    public interface IMoviesService
    {
        void Delete(int id);
        List<MovieViewModel> FetchMoviesWithPagination(int page, int pageSize);
        MovieViewModel Get(int id);
        MovieViewModel Update(MovieUpdateBinding model);
    }
}