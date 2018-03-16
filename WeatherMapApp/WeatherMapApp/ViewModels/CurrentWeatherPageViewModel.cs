using Prism.Commands;
using Prism.Mvvm;
using System;
using WeatherMapApp.Models;
using WeatherMapApp.Services;

namespace WeatherMapApp.ViewModels
{
    public class CurrentWeatherPageViewModel : BindableBase
    {
        private WeatherService _weatherService;
        private Weather _weatherModel;
        private DateTime _weatherTime;

        public Weather CurrentWeather
        {
            get { return _weatherModel; }
            set { SetProperty(ref _weatherModel, value); }
        }

        public DateTime WeatherTime
        {
            get { return _weatherTime; }
            set { SetProperty(ref _weatherTime, value); }
        }

        public DelegateCommand RefreshImageCommand { get; set; }

        public CurrentWeatherPageViewModel()
        {
            RefreshImageCommand = new DelegateCommand(RefreshWeather);

            _weatherService = new WeatherService();
            GetCurrentWeather();
        }

        private void RefreshWeather()
        {
            GetCurrentWeather();
        }

        private async void GetCurrentWeather()
        {
            CurrentWeather = await _weatherService.GetCurrentWeather();
            WeatherTime = UnixTimeStampToDateTime(CurrentWeather.Dt);
        }

        public DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
