using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using WeatherMapApp.Models;
using WeatherMapApp.Services;

namespace WeatherMapApp.ViewModels
{
	public class ForecastPageViewModel : BindableBase
	{
        private WeatherService _weatherService;
        private Forecast _forecast;

        public Forecast Forecast
        {
            get { return _forecast; }
            set { SetProperty(ref _forecast, value); }
        }

        public ForecastPageViewModel()
        {
            _weatherService = new WeatherService();
            GetForecast();
        }

        private async void GetForecast()
        {
            Forecast = await _weatherService.GetForecast();
        }
    }
}
