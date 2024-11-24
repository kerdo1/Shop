using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShopTARge23.Core.Dto.OpenWeather
{
    public class OpenWeatherResultDto
    {
        // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);

        public string CityName { get; set; }
        public double Temperature { get; set; }
        public double FeelsLike { get; set; }  
        public int Humidity { get; set; }
        public int Pressure { get; set; }
        public double WindSpeed { get; set; }
        public string WeatherDescription { get; set; }


    }
}
