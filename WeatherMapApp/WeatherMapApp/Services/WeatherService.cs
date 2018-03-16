using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherMapApp.Models;

namespace WeatherMapApp.Services
{
    public class WeatherService
    {
        private readonly string _APIKey = "58630711909d4c7ebc445ce7d15495ce";
        private readonly string _currentWeatherURL = "http://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&units=metric";
        private readonly string _forecastURL = "http://api.openweathermap.org/data/2.5/forecast?lat={lat}&lon={lon}&units=metric";

        private HttpClient _client = new HttpClient();

        public WeatherService()
        {
                     
        }

        public async Task<string> GetRequest(string URL)
        {
            Location _location = await LocationService.GetCurrentLocation();
            var request = URL.Replace("{lat}", _location.Latitude).Replace("{lon}", _location.Longitude);
            request = System.String.Concat(request, "&APPID=", _APIKey);
            return request;
        }

        public async Task<Weather> GetCurrentWeather()
        {
            var request = await GetRequest(_currentWeatherURL);
            var weather = await _client.GetStringAsync(request);

            return Weather.FromJson(weather);
        }

        public async Task<Forecast> GetForecast()
        {
            var request = await GetRequest(_forecastURL);
            var forecast = await _client.GetStringAsync(request);

            return Forecast.FromJson(forecast);
        }
    }
}
