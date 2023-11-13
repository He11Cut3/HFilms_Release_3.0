using System.ComponentModel.DataAnnotations;

namespace HellsFilms.Models
{
	public class HellsFilmsUser
	{
		public string HellsFilmsUserID { get; set; }

		[Required, MinLength(2, ErrorMessage = "Minimum length is 2")]
		[Display(Name = "Username")]

		public string HellsFilmsUserLogin { get; set; }

		public string HellsFilmsUserEmail { get; set; }

		public string HellsFilmsUserPassword { get; set; }
	}
}
