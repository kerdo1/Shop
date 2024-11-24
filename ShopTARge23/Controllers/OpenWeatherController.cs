using Microsoft.AspNetCore.Mvc;

namespace ShopTARge23.Controllers
{
    public class OpenWeatherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
