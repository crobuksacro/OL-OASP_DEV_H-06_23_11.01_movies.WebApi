using OL_OASP_DEV_H_06_23_11._01_movies.Shared.Models.ViewModels;
using OL_OASP_DEV_H_06_23_11._01_movies.Shared.Services.Interfaces;

namespace OL_OASP_DEV_H_06_23_11._01_movies.Shared.Services.Implementation
{
    public class WebApiFiscalizationServiceClient : WebApiServiceClientBase, IWebApiFiscalizationServiceClient
    {
        public WebApiFiscalizationServiceClient(HttpClient httpClient, Action<HttpResponseMessage> unsuccessfulResponseAction) : base(httpClient, unsuccessfulResponseAction)
        {
        }

        public MovieViewModel GetInvoice(long id, Action<HttpResponseMessage> unsuccessfulResponseAction = null)
        {
            return DoRequestAndTryGetResponseContent<MovieViewModel>($"api/invoice/{id}", HttpMethod.Get, true, unsuccessfulResponseAction);
        }


    }
}
