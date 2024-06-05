using Microsoft.Extensions.DependencyInjection;
using OL_OASP_DEV_H_06_23_11._01_movies.Shared.Services.Interfaces;

namespace OL_OASP_DEV_H_06_23_11._01_movies.Shared.Services.Implementation
{
    public static class WebApiServiceClientCollectionExtension
    {
        /// <summary>
        /// Primjer, ne poziva se nigdje!!
        /// </summary>
        /// <param name="services"></param>
        /// <param name="webApiServiceBaseUrl"></param>
        /// <param name="unsuccessfulResponseAction"></param>
        /// <returns></returns>
        public static IServiceCollection AddWebApiMovieServiceClient(this IServiceCollection services, string webApiServiceBaseUrl, Action<HttpResponseMessage> unsuccessfulResponseAction = null)
        {
            //Potrebno je instalirat pckg Microsoft.Extensions.Http
            services.AddHttpClient(nameof(WebApiMovieServiceClient)).AddTypedClient<IWebApiServiceClient>(c => new WebApiMovieServiceClient(c, unsuccessfulResponseAction))
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri(webApiServiceBaseUrl);
                });

            return services;
        }


        public static IServiceCollection AddWebApiFiscalizationServiceClient(this IServiceCollection services, string webApiServiceBaseUrl, Action<HttpResponseMessage> unsuccessfulResponseAction = null)
        {
            //Potrebno je instalirat pckg Microsoft.Extensions.Http
            services.AddHttpClient(nameof(WebApiFiscalizationServiceClient)).AddTypedClient<IWebApiFiscalizationServiceClient>(c => new WebApiFiscalizationServiceClient(c, unsuccessfulResponseAction))
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri(webApiServiceBaseUrl);
                });

            return services;
        }
    }
}
