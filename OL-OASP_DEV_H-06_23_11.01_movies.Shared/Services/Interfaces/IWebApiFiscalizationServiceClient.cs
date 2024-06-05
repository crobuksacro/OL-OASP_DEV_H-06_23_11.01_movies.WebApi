using OL_OASP_DEV_H_06_23_11._01_movies.Shared.Models.ViewModels;

namespace OL_OASP_DEV_H_06_23_11._01_movies.Shared.Services.Interfaces
{
    public interface IWebApiFiscalizationServiceClient
    {
        MovieViewModel GetInvoice(long id, Action<HttpResponseMessage> unsuccessfulResponseAction = null);
    }
}