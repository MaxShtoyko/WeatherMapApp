using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherMapApp.Models;

namespace WeatherMapApp.Services
{
    public class WeatherService
    {
        private readonly string _APIKey = "58630711909d4c7ebc445ce7d15495ce";
        private readonly string _URL = "http://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}";

        private HttpClient _client = new HttpClient();

        public WeatherService()
        {

        }

        public async Task<Weather> GetCurrentWeather()
        {
            Location _location = await LocationService.GetCurrentLocation();
            var request = _URL.Replace("{lat}", _location.Latitude).Replace("{lon}", _location.Longitude);
            request = System.String.Concat(request, "&APPID=", _APIKey);

            var weather = await _client.GetStringAsync(request);

            return Weather.FromJson(weather);
        }
    }
}
