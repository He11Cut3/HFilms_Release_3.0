using HellsFilms.Controllers;
using HellsFilms.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HellsFilms.Infrastructure.Components
{
    public class SerialFooterViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Используйте ваш KinoboxApiClient, чтобы получить популярные сериалы
            var kinoboxApiClient = new KinoboxApiClient(new HttpClient());
            var popularSeries = await kinoboxApiClient.GetPopularSeriesAsync();

            // Возвращаем результат
            return View(popularSeries);
        }
    }
}
