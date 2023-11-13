using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HellsFilms.Infrastructure.Components
{
	public class TagViewComponent: ViewComponent
	{
		private readonly DataContext _context;

		public TagViewComponent(DataContext context)
		{
			_context = context;
		}

		public async Task<IViewComponentResult> InvokeAsync() => View(await _context.HellsFilmsTags.ToListAsync());
	}
}
