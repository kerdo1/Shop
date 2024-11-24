using Microsoft.AspNetCore.Mvc;
using ShopTARge23.Core.Dto.Games;
using ShopTARge23.Core.ServiceInterface;

namespace ShopTARge23.Controllers
{
    public class GamesController : Controller
    {

        private readonly IGameService _gameService;

        public GamesController (
            IGameService gameService)
        {
            _gameService = gameService;
        }

        public async Task<IActionResult> Index()
        {
            var games = await _gameService.GetGamesAsync();

            if (games == null || !games.Any())

            {
                games = new List<GameRootDto> ();
            }

            return View(games);
        }


    }
}
