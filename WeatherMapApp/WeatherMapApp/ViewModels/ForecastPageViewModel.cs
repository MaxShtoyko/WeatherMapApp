using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WeatherMapApp.Models;
using WeatherMapApp.Services;

namespace WeatherMapApp.ViewModels
{
    public class DailyForecast<T> : ObservableCollection<T>
    {
        public DayOfWeek Day { get; private set; }
        public DailyForecast(DayOfWeek _day, IEnumerable<T> items)
        {
            Day = _day;
            foreach (var item in items)
                Items.Add(item);
        }
    }

    public class ForecastPageViewModel : BindableBase
	{
        private WeatherService _weatherService;
        private Forecast _forecastByHours;
        private ObservableCollection<DailyForecast<List>> _forecastByDays;

        public Forecast ForecastByHours
        {
            get { return _forecastByHours; }
            set { SetProperty(ref _forecastByHours, value); }
        }

        public ObservableCollection<DailyForecast<List>> ForecastByDays
        {
            get { return _forecastByDays; }
            set { SetProperty(ref _forecastByDays, value); }
        }

        public ForecastPageViewModel()
        {
            _weatherService = new WeatherService();
            GetForecast();          
        }

        private async void GetForecast()
        {
            ForecastByHours = await _weatherService.GetForecast();
            var forecastByDays = ForecastByHours.forecasts.GroupBy(forecast => forecast.Data.DayOfWeek).Select(g => new DailyForecast<List>(g.Key, g));
            ForecastByDays = new ObservableCollection<DailyForecast<List>>(forecastByDays);
        }
    }
}
