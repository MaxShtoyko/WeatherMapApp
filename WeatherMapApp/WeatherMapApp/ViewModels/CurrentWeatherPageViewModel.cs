using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Threading.Tasks;
using WeatherMapApp.Models;
using WeatherMapApp.Services;

namespace WeatherMapApp.ViewModels
{
    public class CurrentWeatherPageViewModel : BindableBase, INavigationAware
    {
        private Weather _weatherModel;
        private DateTime _weatherTime;
        private IPageDialogService _pageService;

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

        public CurrentWeatherPageViewModel(IPageDialogService pageService)
        {
            RefreshImageCommand = new DelegateCommand(RefreshWeather);

            _pageService = pageService;
        }

        private async void RefreshWeather()
        {
            await GetCurrentWeather();
        }

        private async Task GetCurrentWeather()
        {
            CurrentWeather = await WeatherService.GetCurrentWeather();
            WeatherTime = UnixTimeStampToDateTime(CurrentWeather.Dt);
        }

        public DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            await GetCurrentWeather();
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
        }
    }
}
