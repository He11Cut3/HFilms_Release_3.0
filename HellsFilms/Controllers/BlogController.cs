using HellsFilms.Infrastructure;
using HellsFilms.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HellsFilms.Controllers
{
	public class BlogController : Controller
	{
		private readonly DataContext _context;

		public BlogController(DataContext context)
		{
			_context = context;
		}

		public async Task<HellsFilmsBlog> Load(long id)
		{
			return await _context.HellsFilmsBlogs.FirstOrDefaultAsync(p => p.HellsFilmsBlogID == id);
		}

		public async Task<IActionResult> Index(long? tagID)
		{

			var tagblog = await _context.HellsFilmsTags.ToListAsync();
			IQueryable<HellsFilmsBlog> productsQuery = _context.HellsFilmsBlogs;

			// Фильтрация товаров по категории, если categoryId указан
			if (tagID.HasValue)
			{
				productsQuery = productsQuery.Where(p => p.HellsFilmsTagID == tagID.Value);
			}

			var products = await productsQuery.ToListAsync();

			// Здесь вы можете передать данные в представление, включая categoryId
			return View(products.ToList());
		}

		public async Task<IActionResult> Details(long id)
		{
			var blogonl = await Load(id);

			if (blogonl == null)
			{
				return NotFound();
			}
			return View(blogonl);
		}
	}
}
