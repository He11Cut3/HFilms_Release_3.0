using HellsFilms.Infrastructure;
using HellsFilms.Models;
using HellsFilms.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web;

namespace HellsFilms.Controllers
{
    public class MovieListController : Controller
    {
        private readonly KinoboxApiClient _kinoboxApiClient;

        public MovieListController(KinoboxApiClient kinoboxApiClient)
        {
            _kinoboxApiClient = kinoboxApiClient;
        }

        public async Task<IActionResult> Index()
        {
            var popularMovies = await _kinoboxApiClient.GetPopularFilmsAsync();
            return View(popularMovies);
        }

        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Search(string query)
        {
            // Проверяем, является ли запрос числовым значением (ID)
            if (int.TryParse(query, out _))
            {
                // Если запрос числовой, ищем по ID
                var searchResults = _kinoboxApiClient.SearchFilmsAsync(query).Result;

                // Передаем результаты и запрос в представление
                ViewBag.Query = query;
                return View("SearchResults", searchResults);
            }
            else
            {
                // Если запрос не числовой, кодируем его и ищем по наименованию
                var encodedQuery = HttpUtility.UrlEncode(query);
                var searchResults = _kinoboxApiClient.SearchFilmsAsync(encodedQuery).Result;

                // Передаем результаты и запрос в представление
                ViewBag.Query = query;
                return View("SearchResults", searchResults);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(string kinopoiskId)
        {
            var players = await _kinoboxApiClient.GetMainPlayersAsync(kinopoiskId);
            var player = players?.FirstOrDefault();

            if (player != null)
            {
                player.KinopoiskId = kinopoiskId; // Установите значение KinopoiskId
                return View("Details", player);
            }
            else
            {
                return View("PlayerNotFound");
            }
        }



    }
}
