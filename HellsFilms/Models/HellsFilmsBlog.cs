using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HellsFilms.Infrastructure.Validation;

namespace HellsFilms.Models
{
    public class HellsFilmsBlog
    {
        public long HellsFilmsBlogID { get; set; }

        public string HellsFilmsBlogName { get; set; }

        public string HellsFilmsBlogDate { get; set; }

        public byte[] HellsFilmsBlogPhoto { get; set; }

        public string HellsFilmsBlogDescription { get; set; }

        public long HellsFilmsTagID { get; set; }

        public HellsFilmsTag HellsFilmsBlogTag { get; set; }

        [NotMapped]
        [FileExtension]
        public IFormFile ImageUpload { get; set; }
    }
}
