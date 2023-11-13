using Microsoft.AspNetCore.Mvc;

namespace HellsFilms.Controllers
{
    public class SearchController : Controller
    {
        private readonly KinoboxApiClient _kinoboxApiClient;

        public SearchController(KinoboxApiClient kinoboxApiClient)
        {
            _kinoboxApiClient = kinoboxApiClient;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string searchTerm)
        {
            return View();
        }
    }
}
