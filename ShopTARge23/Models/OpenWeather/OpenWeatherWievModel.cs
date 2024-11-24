namespace ShopTARge23.Models.OpenWeather
{
    public class OpenWeatherWievModel
    {
        public string CityName { get; set; }          
        public double Temperature { get; set; }      
        public int Humidity { get; set; }            
        public int Pressure { get; set; }            
        public double WindSpeed { get; set; }        
        public string WeatherDescription { get; set; }
    }
}
