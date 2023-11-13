using HellsFilms.Models;
using HellsFilms.Models.ViewModels;
using Newtonsoft.Json;

namespace HellsFilms.Controllers
{
    public class KinoboxApiClient
    {
        private readonly HttpClient _httpClient;

        public KinoboxApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpClient.BaseAddress = new Uri("https://kinobox.tv"); // Укажите реальный базовый адрес API
        }

        public async Task<List<Player>> GetMainPlayersAsync(string kinopoiskId)
        {
            var url = $"/api/players/main?kinopoisk={kinopoiskId}";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Player>>(content);
            }

            // Handle error here if needed
            return null;
        }

        public async Task<List<BasicFilm>> SearchFilmsAsync(string title)
        {
            var url = $"/api/films/search?title={title}";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<BasicFilm>>(content);
            }

            // Handle error here if needed
            return null;
        }


        public async Task<List<BasicFilm>> GetPopularSeriesAsync()
        {
            var url = "/api/popular/series";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<BasicFilm>>(content);
            }

            // Handle error here if needed
            return null;
        }
        public async Task<List<BasicFilm>> GetPopularFilmsAsync()
        {
            var url = "/api/popular/films";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<BasicFilm>>(content);
            }

            // Handle error here if needed
            return null;
        }


        public async Task<List<Player>> SearchMainPlayersAsync(string kinopoiskId)
    {
        var url = $"/api/players/main?kinopoisk={kinopoiskId}";

        var response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Player>>(content);
        }

        // Handle error here if needed
        return null;
    }

    public async Task<List<Player>> SearchAllPlayersAsync(string title)
    {
        var url = $"/api/players/all?title={title}";

        var response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Player>>(content);
        }

        // Handle error here if needed
        return null;
    }

        public async Task<List<Player>> GetAllPlayersAsync(string kinopoisk = null, string imdb = null, string title = null, string token = null)
        {
            var url = $"/api/players/all?kinopoisk={kinopoisk}&imdb={imdb}&title={title}&token={token}";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Player>>(content);
            }

            // Handle error here if needed
            return null;
        }
        public async Task<List<Player>> GetMoviePlayersAsync(string kinopoisk)
        {
            var url = $"/api/players/main?kinopoisk={kinopoisk}";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Player>>(content);
            }

            // Обработка ошибок здесь, если это необходимо
            return null;
        }
    }

    public class Player
    {
        public string KinopoiskId { get; set; } // Добавьте это свойство
        public PlayerSource Source { get; set; }
        public string Translation { get; set; }
        public string Quality { get; set; }
        public string IframeUrl { get; set; }
        public DateTime UpdatedAt { get; set; }

        public string FilmTitle { get; set; }
        public string AlternativeTitle { get; set; }
        public int FilmYear { get; set; }
        public double? FilmRating { get; set; }
        public string PosterUrl { get; set; }
    }

    public enum PlayerSource
    {
        Alloha,
        Ashdi,
        Bazon,
        Cdnmovies,
        Collaps,
        Hdvb,
        Iframe,
        Kodik,
        Videocdn,
        Voidboost
    }
}
