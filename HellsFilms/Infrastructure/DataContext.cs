using HellsFilms.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HellsFilms.Infrastructure
{
    public class DataContext: IdentityDbContext<AppUser>
	{
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<HellsFilmsTag> HellsFilmsTags { get; set; }

        public DbSet<HellsFilmsBlog> HellsFilmsBlogs { get; set; }

        public DbSet<HellsFilmsMovie> HellsFilmsMovies { get; set; }

        public DbSet<HellsFilmsSerial> HellsFilmsSerials { get; set; }

	}
}
