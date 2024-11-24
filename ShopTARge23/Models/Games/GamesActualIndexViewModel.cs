using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopTARge23.ApplicationServices.Services;

namespace ShopTARge23.Models.Games
{
    public class GamesActualIndexViewModel : PageModel
    {
        private readonly GameService _gameService;

        // Correct the type here to match the data model

        public List<GamesIndexViewModel> Games { get; set; }

        public GamesActualIndexViewModel(GameService gameService)
        {
            _gameService = gameService;
        }

        public async Task OnGetAsync()
        {
            // Fetch games from the GameService
            var gameDtos = await _gameService.GetGamesAsync();

            // Map GameRootDto to GamesIndexViewModel
            Games = gameDtos.Select(gameDto => new GamesIndexViewModel
            {
                Id = gameDto.id,
                Title = gameDto.title,
                Thumbnail = gameDto.thumbnail,
                ShortDescription = gameDto.short_description,
                GameUrl = gameDto.game_url,
                Genre = gameDto.genre,
                Platform = gameDto.platform,
                Publisher = gameDto.publisher,
                Developer = gameDto.developer,
                ReleaseDate = gameDto.release_date,
                FreetogameProfileUrl = gameDto.freetogame_profile_url
            }).ToList();
        }

    }
}
