using HellsFilms.Infrastructure;
using HellsFilms.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Hells_Tire.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AdminMovieController : Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminMovieController(DataContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

		public async Task<IActionResult> Index()
		{
			int rowCount = _context.HellsFilmsMovies.Count(); // YourEntity - это название вашей сущности

			ViewBag.RowCount = rowCount;
			var latestMovies = await _context.HellsFilmsMovies.ToListAsync();

			return View(latestMovies);
		}

		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(HellsFilmsMovie user)
		{
			_context.HellsFilmsMovies.Add(user);
			await _context.SaveChangesAsync();
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Edit(long id)
        {
			HellsFilmsMovie product = await _context.HellsFilmsMovies.FindAsync(id);

            return View(product);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(HellsFilmsMovie product, int? id)
        {
            if (ModelState.IsValid)
            {
                // Если у вас есть какой-то уникальный идентификатор для продукта (например, HellsTireProductID), используйте его
                // В данном примере, я предполагаю, что у продукта есть уникальное поле HellsTireProductID
                var existingProduct = await _context.HellsFilmsMovies.FirstOrDefaultAsync(p => p.HellsFilmsMovieID == id);

                if (existingProduct != null)
                {
					// Обновляем существующий продукт с новыми данными
					existingProduct.HellsFilmsMovieName = product.HellsFilmsMovieName;
					existingProduct.HellsFilmsMoviePhoto = product.HellsFilmsMoviePhoto;
					existingProduct.HellsFilmsMovieDate = product.HellsFilmsMovieDate;
					existingProduct.HellsFilmsMovieRating = product.HellsFilmsMovieRating;
					existingProduct.HellsFilmsMovieIDFilms = product.HellsFilmsMovieIDFilms;
					// Продолжайте обновлять другие свойства продукта по необходимости

					// Проверяем, загружено ли новое изображение

                    // Обновляем запись в базе данных
                    _context.HellsFilmsMovies.Update(existingProduct);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction("Index");
            }

            return View(product);
        }
        public async Task<IActionResult> Delete(long id)
        {
			HellsFilmsMovie product = await _context.HellsFilmsMovies.FindAsync(id);

            _context.HellsFilmsMovies.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}
