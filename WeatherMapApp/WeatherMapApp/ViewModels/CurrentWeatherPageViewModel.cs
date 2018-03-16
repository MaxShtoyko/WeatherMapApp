using Prism.Commands;
using Prism.Mvvm;
using WeatherMapApp.Models;
using WeatherMapApp.Services;

namespace WeatherMapApp.ViewModels
{
    public class CurrentWeatherPageViewModel : BindableBase
    {
        private WeatherService _weatherService;
        private Weather _weatherModel;

        public Weather CurrentWeather
        {
            get { return _weatherModel; }
            set { SetProperty(ref _weatherModel, value); }
        }

        public DelegateCommand RefreshImageCommand { get; set; }

        public CurrentWeatherPageViewModel()
        {
            RefreshImageCommand = new DelegateCommand(RefreshWeather);

            _weatherService = new WeatherService();
            GetCurrentWeather();
        }

        private async void GetCurrentWeather()
        {
            CurrentWeather = await _weatherService.GetCurrentWeather();
        }

        private void RefreshWeather()
        {
            GetCurrentWeather();
        }
    }
}
