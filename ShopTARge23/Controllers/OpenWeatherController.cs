using Microsoft.AspNetCore.Mvc;
using ShopTARge23.ApplicationServices.Services;
using ShopTARge23.Core.ServiceInterface;
using ShopTARge23.Models.OpenWeather;

namespace ShopTARge23.Controllers
{
    public class OpenWeatherController : Controller
    {
        private readonly IOpenWeatherServices _weatherService;

        public OpenWeatherController(IOpenWeatherServices weatherService)
        {
            _weatherService = weatherService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet, HttpPost]
        public async Task<IActionResult> CityData(string city)
        {
            try
            {
                // Get data for weather and return it to view
                var weather = await _weatherService.GetWeatherByCity(city);

                // Map OpenWeatherResultDto to OpenWeatherWievModel
                var viewModel = new OpenWeatherWievModel
                {
                    CityName = weather.CityName,
                    Temperature = weather.Temperature,
                    FeelsLike = weather.FeelsLike,
                    Humidity = weather.Humidity,
                    Pressure = weather.Pressure,
                    WindSpeed = weather.WindSpeed,
                    WeatherDescription = weather.WeatherDescription
                };

                // Pass the mapped model to the view
                return View("Data", viewModel);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Could not fetch weather data. Please check the city name.";
                return View("Index");
            }
        }
    }
}
