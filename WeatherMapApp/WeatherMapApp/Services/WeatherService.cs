using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherMapApp.Models;

namespace WeatherMapApp.Services
{
    public class WeatherService
    {
        private readonly string _APIkey = "58630711909d4c7ebc445ce7d15495ce";
        private readonly string _URL = "api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}";

        private HttpClient _client = new HttpClient();

        public WeatherService()
        {

        }

        public async Task<WeatherModel> GetCurrentWeather()
        {
            Location _location = await LocationService.GetLocation();
            var request = _URL.Replace("{lat}", _location.Latitude).Replace("{lon}", _location.Longitude);
            var weather = await _client.GetStringAsync(request);

            var weatherModel = JsonConvert.DeserializeObject<WeatherModel>(weather);

            return weatherModel;
        }
    }
}
