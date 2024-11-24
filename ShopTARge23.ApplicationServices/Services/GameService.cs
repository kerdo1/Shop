using System.Net.Http.Json;
using ShopTARge23.Core.Dto.Games;
using ShopTARge23.Core.ServiceInterface;
namespace ShopTARge23.ApplicationServices.Services
{
    public class GameService : IGameService
    {
        private readonly HttpClient _httpClient;

        public GameService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GameRootDto>> GetGamesAsync()
        {
            var games = await _httpClient.GetFromJsonAsync<List<GameRootDto>>("https://www.freetogame.com/api/games");
            return games ?? new List<GameRootDto>();
        }
    }
}
