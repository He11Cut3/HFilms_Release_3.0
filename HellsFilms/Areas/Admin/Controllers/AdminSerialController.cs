using HellsFilms.Infrastructure;
using HellsFilms.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HellsFilms.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class AdminSerialController : Controller
	{
		private readonly DataContext _context;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public AdminSerialController(DataContext context, IWebHostEnvironment webHostEnvironment)
		{
			_context = context;
			_webHostEnvironment = webHostEnvironment;
		}

		public async Task<IActionResult> Index()
		{
			int rowCount = _context.HellsFilmsSerials.Count(); // YourEntity - это название вашей сущности

			ViewBag.RowCount = rowCount;
			var latestMovies = await _context.HellsFilmsSerials.ToListAsync();

			return View(latestMovies);
		}

		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(HellsFilmsSerial user)
		{
			_context.HellsFilmsSerials.Add(user);
			await _context.SaveChangesAsync();
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Edit(long id)
		{
			HellsFilmsSerial product = await _context.HellsFilmsSerials.FindAsync(id);

			return View(product);


		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(HellsFilmsSerial product, int? id)
		{
			if (ModelState.IsValid)
			{
				// Если у вас есть какой-то уникальный идентификатор для продукта (например, HellsTireProductID), используйте его
				// В данном примере, я предполагаю, что у продукта есть уникальное поле HellsTireProductID
				var existingProduct = await _context.HellsFilmsSerials.FirstOrDefaultAsync(p => p.HellsFilmsSerialID == id);

				if (existingProduct != null)
				{
					// Обновляем существующий продукт с новыми данными
					existingProduct.HellsFilmsSerialName = product.HellsFilmsSerialName;
					existingProduct.HellsFilmsSerialPhoto = product.HellsFilmsSerialPhoto;
					existingProduct.HellsFilmsSerialDate = product.HellsFilmsSerialDate;
					existingProduct.HellsFilmsSerialRating = product.HellsFilmsSerialRating;
					existingProduct.HellsFilmsSerialIDSerial = product.HellsFilmsSerialIDSerial;
					// Продолжайте обновлять другие свойства продукта по необходимости

					// Проверяем, загружено ли новое изображение

					// Обновляем запись в базе данных
					_context.HellsFilmsSerials.Update(existingProduct);
					await _context.SaveChangesAsync();
				}

				return RedirectToAction("Index");
			}

			return View(product);
		}
		public async Task<IActionResult> Delete(long id)
		{
			HellsFilmsSerial product = await _context.HellsFilmsSerials.FindAsync(id);

			_context.HellsFilmsSerials.Remove(product);
			await _context.SaveChangesAsync();

			return RedirectToAction("Index");
		}
	}
}
