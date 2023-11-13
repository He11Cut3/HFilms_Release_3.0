using HellsFilms.Infrastructure;
using HellsFilms.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HellsFilms.Controllers
{
	public class SerialController : Controller
	{

        private readonly KinoboxApiClient _kinoboxApiClient;

        public SerialController(KinoboxApiClient kinoboxApiClient)
        {
            _kinoboxApiClient = kinoboxApiClient;
        }

        public async Task<IActionResult> Index()
        {
            var popularMovies = await _kinoboxApiClient.GetPopularSeriesAsync();
            return View(popularMovies);
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
