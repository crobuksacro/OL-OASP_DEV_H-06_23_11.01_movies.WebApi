using Microsoft.AspNetCore.Mvc;
using OL_OASP_DEV_H_06_23_11._01_movies.Shared.Services.Interfaces;

namespace OL_OASP_DEV_H_06_23_11._01_movies.WebApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IWebApiServiceClient webApiServiceClient;

        public MoviesController(IWebApiServiceClient webApiServiceClient)
        {
            this.webApiServiceClient = webApiServiceClient;
        }

        public IActionResult Index()
        {
            var response = webApiServiceClient.GetMovies();
            return View(response);
        }

    }
}
