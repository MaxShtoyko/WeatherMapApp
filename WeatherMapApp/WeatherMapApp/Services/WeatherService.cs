using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherMapApp.Models;

namespace WeatherMapApp.Services
{
    public static class WeatherService
    {
        private static readonly string _APIKey = "58630711909d4c7ebc445ce7d15495ce";
        private static readonly string _currentWeatherURL = "http://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&units=metric";
        private static readonly string _forecastURL = "http://api.openweathermap.org/data/2.5/forecast?lat={lat}&lon={lon}&units=metric";

        private static HttpClient _client = new HttpClient();

        static WeatherService()
        {
                     
        }

        public static async Task<string> GetRequest(string URL)
        {
            Location _location = await LocationService.GetCurrentLocation();
            var request = URL.Replace("{lat}", _location.Latitude).Replace("{lon}", _location.Longitude);
            request = System.String.Concat(request, "&APPID=", _APIKey);
            return request;
        }

        public static async Task<Weather> GetCurrentWeather()
        {
            var request = await GetRequest(_currentWeatherURL);
            var weather = await _client.GetStringAsync(request);

            return Weather.FromJson(weather);
        }

        public static async Task<Forecast> GetForecast()
        {
            var request = await GetRequest(_forecastURL);
            var forecast = await _client.GetStringAsync(request);

            return Forecast.FromJson(forecast);
        }
    }
}
