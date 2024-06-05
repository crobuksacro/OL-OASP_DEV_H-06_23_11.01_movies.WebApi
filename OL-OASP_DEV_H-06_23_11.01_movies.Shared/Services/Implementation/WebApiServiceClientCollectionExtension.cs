using Microsoft.Extensions.DependencyInjection;
using OL_OASP_DEV_H_06_23_11._01_movies.Shared.Services.Interfaces;

namespace OL_OASP_DEV_H_06_23_11._01_movies.Shared.Services.Implementation
{
    public static class WebApiServiceClientCollectionExtension
    {

        public static IServiceCollection AddWebApiServiceClient(this IServiceCollection services, string webApiServiceBaseUrl, Action<HttpResponseMessage> unsuccessfulResponseAction = null)
        {
            //Potrebno je instalirat pckg Microsoft.Extensions.Http
            services.AddHttpClient(nameof(WebApiServiceClient)).AddTypedClient<IWebApiServiceClient>(c => new WebApiServiceClient(c, unsuccessfulResponseAction))
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri(webApiServiceBaseUrl);
                });

            return services;
        }
    }
}
