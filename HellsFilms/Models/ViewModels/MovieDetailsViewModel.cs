using HellsFilms.Controllers;

namespace HellsFilms.Models.ViewModels
{
    public class MovieDetailsViewModel
    {
        public List<BasicFilm> Films { get; set; }
        public List<Player> Players { get; set; }
    }
}
