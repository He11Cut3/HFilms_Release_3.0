using HellsFilms.Infrastructure;
using HellsFilms.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HellsFilms.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]

	public class AdminBlogController : Controller
	{
		private readonly DataContext _context;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public AdminBlogController(DataContext context, IWebHostEnvironment webHostEnvironment)
		{
			_context = context;
			_webHostEnvironment = webHostEnvironment;
		}

		public async Task<IActionResult> Index()
		{
			int rowCount = _context.HellsFilmsBlogs.Count(); // YourEntity - это название вашей сущности

			ViewBag.RowCount = rowCount;
			var latestMovies = await _context.HellsFilmsBlogs.ToListAsync();

			return View(latestMovies);
		}

		public IActionResult Create()
		{
            ViewBag.Tag = new SelectList(_context.HellsFilmsTags, "HellsFilmsTagID", "HellsFilmsTagName");

            return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(HellsFilmsBlog user)
		{
            ViewBag.Tag = new SelectList(_context.HellsFilmsTags, "HellsFilmsTagID", "HellsFilmsTagName", user.HellsFilmsTagID);

            if (user.ImageUpload != null && user.ImageUpload.Length > 0)
			{
				using (var ms = new MemoryStream())
				{
					await user.ImageUpload.CopyToAsync(ms);
					user.HellsFilmsBlogPhoto = ms.ToArray();
				}
			}
			_context.HellsFilmsBlogs.Add(user);
			await _context.SaveChangesAsync();
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Edit(long id)
		{
			HellsFilmsBlog product = await _context.HellsFilmsBlogs.FindAsync(id);

			if (product != null)
			{
                ViewBag.Tag = new SelectList(_context.HellsFilmsTags, "HellsFilmsTagID", "HellsFilmsTagName", product.HellsFilmsTagID);
            }

			return View(product);


		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(HellsFilmsBlog product, int? id)
		{
            ViewBag.Tag = new SelectList(_context.HellsFilmsTags, "HellsFilmsTagID", "HellsFilmsTagName", product.HellsFilmsTagID);

            if (ModelState.IsValid)
			{
				// Если у вас есть какой-то уникальный идентификатор для продукта (например, HellsTireProductID), используйте его
				// В данном примере, я предполагаю, что у продукта есть уникальное поле HellsTireProductID
				var existingProduct = await _context.HellsFilmsBlogs.FirstOrDefaultAsync(p => p.HellsFilmsBlogID == id);

				if (existingProduct != null)
				{
					// Обновляем существующий продукт с новыми данными
					existingProduct.HellsFilmsBlogName = product.HellsFilmsBlogName;
					existingProduct.HellsFilmsBlogDate = product.HellsFilmsBlogDate;
					//existingProduct.HellsFilmsBlogPhoto = product.HellsFilmsMovieDate;
					existingProduct.HellsFilmsBlogDescription = product.HellsFilmsBlogDescription;
					existingProduct.HellsFilmsTagID = product.HellsFilmsTagID;
					// Продолжайте обновлять другие свойства продукта по необходимости
					if (product.ImageUpload != null && product.ImageUpload.Length > 0)
					{
						using (var ms = new MemoryStream())
						{
							await product.ImageUpload.CopyToAsync(ms);
							existingProduct.HellsFilmsBlogPhoto = ms.ToArray();
						}
					}
					// Проверяем, загружено ли новое изображение

					// Обновляем запись в базе данных
					_context.HellsFilmsBlogs.Update(existingProduct);
					await _context.SaveChangesAsync();
				}

				return RedirectToAction("Index");
			}

			return View(product);
		}
		public async Task<IActionResult> Delete(long id)
		{
			HellsFilmsBlog product = await _context.HellsFilmsBlogs.FindAsync(id);

			_context.HellsFilmsBlogs.Remove(product);
			await _context.SaveChangesAsync();

			return RedirectToAction("Index");
		}
	}
}
