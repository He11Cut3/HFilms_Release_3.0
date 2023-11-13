using Microsoft.AspNetCore.Identity;

namespace HellsFilms.Models
{
	public class AppUser : IdentityUser
	{
		public string Usr { get;set; }
	}
}
