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
    public class WebApiServiceClient : IWebApiServiceClient
    {
        private readonly HttpClient httpClient;
        private readonly Action<HttpResponseMessage> unsuccessfulResponseAction;
        private readonly JsonSerializerOptions jsonSerializerOptions;

        public WebApiServiceClient(HttpClient httpClient, Action<HttpResponseMessage> unsuccessfulResponseAction)
        {
            this.httpClient = httpClient;
            this.unsuccessfulResponseAction = unsuccessfulResponseAction;
            jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
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


        private T DoRequestAndTryGetResponseContent<T>(string url, HttpMethod httpMethod, bool readResponseBody,
Action<HttpResponseMessage> unsuccessfulResponseAction, object contentObj = null)
        {
            var responseMessage = DoRequest(url, httpMethod, contentObj: contentObj);

            return TryGetResponseContent<T>(responseMessage, readResponseBody, unsuccessfulResponseAction);
        }
        private T TryGetResponseContent<T>(HttpResponseMessage responseMessage, bool readResponseBody, Action<HttpResponseMessage> unsuccessfulResponseAction)
        {

            if (responseMessage.IsSuccessStatusCode)
            {
                if (readResponseBody)
                {
                    var response = responseMessage.Content.ReadAsStringAsync().Result;

                    var responseObj = JsonSerializer.Deserialize<T>(response, jsonSerializerOptions);


                    return responseObj;
                }
            }
            else
            {
                var action = unsuccessfulResponseAction ?? this.unsuccessfulResponseAction;

                action?.Invoke(responseMessage);
            }

            return default(T);
        }

        private HttpResponseMessage DoRequest(string url, HttpMethod httpMethod, object contentObj = null)
        {
            var request = new HttpRequestMessage(httpMethod, url);
            if (contentObj != null)
            {
                HttpContent content = new StringContent(JsonSerializer.Serialize(contentObj), Encoding.UTF8, "application/json");


                request.Content = content;
            }

            if (httpMethod == HttpMethod.Get)
            {
                return httpClient.SendAsync(request).Result;

            }

            if (httpMethod == HttpMethod.Delete)
            {
                return httpClient.DeleteAsync(url).Result;
            }

            if (httpMethod == HttpMethod.Put)
            {

                return httpClient.PutAsync(url, request.Content).Result;
            }

            return httpClient.PostAsync(url, request.Content).Result;
        }
    }
}
