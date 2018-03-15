using Prism.Mvvm;
using WeatherMapApp.Models;
using WeatherMapApp.Services;

namespace WeatherMapApp.ViewModels
{
    public class CurrentWeatherPageViewModel : BindableBase
    {
        private WeatherService _weatherService;
        private WeatherModel _weatherModel;

        public WeatherModel CurrentWeather
        {
            get { return _weatherModel; }
            set { SetProperty(ref _weatherModel, value); }
        }

        public CurrentWeatherPageViewModel()
        {
            _weatherService = new WeatherService();
            GetCurrentWeather();
        }

        private async void GetCurrentWeather()
        {
            CurrentWeather = await _weatherService.GetCurrentWeather();
        }
	}
}
