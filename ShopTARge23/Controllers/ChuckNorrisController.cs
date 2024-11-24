using Microsoft.AspNetCore.Mvc;
using ShopTARge23.Core.ServiceInterface;
using ShopTARge23.Models.ChuckNorris;

namespace ShopTARge23.Controllers
{
    public class ChuckNorrisController : Controller
    {
        private readonly IChuckNorrisServices _chuckNorrisServices;


        public ChuckNorrisController(
            IChuckNorrisServices chuckNorrisServices)
        {
            _chuckNorrisServices = chuckNorrisServices;
        }
        [HttpPost]
        public async Task<IActionResult> SearchCity()
        {
            // Fetch a new joke
            var joke = await _chuckNorrisServices.GetRandomJoke();

            // Create the ViewModel to pass to the Joke view
            var jokeViewModel = new ChuckNorrisJokeViewModel
            {
                created_at = joke.created_at,
                icon_url = joke.icon_url,
                id = joke.id,
                url = joke.url,
                value = joke.value
            };

            // Return the Joke view and pass the Joke ViewModel
            return View("Joke", jokeViewModel);
        }

        // The Index view action
        public IActionResult Index()
        {
            return View();
        }
    }
}
