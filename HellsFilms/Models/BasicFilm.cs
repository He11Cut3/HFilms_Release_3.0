using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HellsFilms.Models
{
    public class BasicFilm
    {
        public string Id { get; set; }
        public string PrimaryTitle { get; set; }
        public string AlternativeTitle { get; set; }
        public int? Year { get; set; }
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate, NullValueHandling = NullValueHandling.Ignore)]
        public double? Rating { get; set; }

        public string PosterUrl { get; set; }
    }
}
