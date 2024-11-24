using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using ShopTARge23.Core.Dto.OpenWeather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopTARge23.Core.Dto.OpenWeather;
using ShopTARge23.Core.ServiceInterface;


namespace ShopTARge23.ApplicationServices.Services
{
    public class OpenWeatherService : IOpenWeatherServices
    {
        private readonly HttpClient _httpClient;
        private const string key = "7f004857f6ed8a2ef4a2842802e54b1e";
        public OpenWeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<OpenWeatherResultDto> GetWeatherByCity(string city)
        {
            try
            {
                //call API
                var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={key}&units=metric";
                var response = await _httpClient.GetStringAsync(url);

                // deserialise API to root dto
                var weatherData = JsonConvert.DeserializeObject<OpenWeatherRootDto.Root>(response);

                // map API respone to result dto
                return new OpenWeatherResultDto
                {
                    CityName = weatherData.name,
                    Temperature = weatherData.main.temp,
                    Humidity = weatherData.main.humidity,
                    Pressure = weatherData.main.pressure,
                    WindSpeed = weatherData.wind.speed,
                    WeatherDescription = weatherData.weather.FirstOrDefault()?.description
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch or map weather data for city: {city}", ex);
            }



        }
    }
}