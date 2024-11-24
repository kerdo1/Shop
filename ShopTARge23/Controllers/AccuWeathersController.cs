using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopTARge23.ApplicationServices.Services;
using ShopTARge23.Core.Dto;
using ShopTARge23.Core.Dto.WeatherDtos.AccuWeatherDto;
using ShopTARge23.Core.ServiceInterface;
using ShopTARge23.Data;
using ShopTARge23.Models.AccuWeather;
using ShopTARge23.Models.AccuWeathers;
using ShopTARge23.Models.Spaceships;
using static System.Net.Mime.MediaTypeNames;

namespace ShopTARge23.Controllers
{
    public class AccuWeathersController : Controller
    {

        private readonly IWeatherForecastServices _weatherForecastServices;

        public AccuWeathersController(

            IWeatherForecastServices weatherForecastServices
            )
        {
            _weatherForecastServices = weatherForecastServices;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchCity(AccuWeatherIndex model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "AccuWeathers", new { city = model.CityName });
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult City(string city) 
        {
            AccuLocationWeatherResultDto dto = new();
            dto.CityName = city;

            _weatherForecastServices.AccuWeatherResult(dto);
            AccuWeatherViewModel vm = new();
            vm.EffectiveDate = dto.EffectiveDate;
            vm.EffectiveEpochDate = dto.EffectiveEpochDate;
            vm.Severity = dto.Severity;
            vm.Text = dto.Text;
            vm.Category = dto.Category;
            vm.EndDate = dto.EndDate;
            vm.EndEpochDate = dto.EndEpochDate;
            vm.DailyForecastsDate = dto.DailyForecastsDate;
            vm.DailyForecastsEpochDate = dto.DailyForecastsEpochDate;

            vm.TempMinValue = dto.TempMinValue;
            vm.TempMinUnit = dto.TempMinUnit;
            vm.TempMinUnitType = dto.TempMinUnitType;

            vm.TempMaxValue = dto.TempMaxValue;
            vm.TempMaxUnit = dto.TempMaxUnit;
            vm.TempMaxUnitType = dto.TempMaxUnitType;

            vm.DayIcon = dto.DayIcon;
            vm.DayIconPhrase = dto.DayIconPhrase;
            vm.DayHasPrecipitation = dto.DayHasPrecipitation;
            vm.DayPrecipitationType = dto.DayPrecipitationType;
            vm.DayPrecipitationIntensity = dto.DayPrecipitationIntensity;

            vm.NightIcon = dto.NightIcon;
            vm.NightIconPhrase = dto.NightIconPhrase;
            vm.NightHasPrecipitation = dto.NightHasPrecipitation;
            vm.NightPrecipitationType = dto.NightPrecipitationType;
            vm.NightPrecipitationIntensity = dto.NightPrecipitationIntensity;

            vm.MobileLink = dto.MobileLink;
            vm.Link = dto.Link;

            return View(vm);
        }
    }
}
