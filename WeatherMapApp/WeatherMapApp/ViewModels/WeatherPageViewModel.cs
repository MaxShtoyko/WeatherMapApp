using Prism.Navigation;
using System.ComponentModel;
using WeatherMapApp.Models;
using WeatherMapApp.Services;

namespace WeatherMapApp.ViewModels
{
    public class WeatherPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private Location _currentLocation;
        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                SetProperty(ref _currentLocation, value);
            }
        }

        public WeatherPageViewModel( INavigationService navigationService ) 
             : base (navigationService)
        {
            Title = "Weather Page";
            SetLocation();
        }

        public async void SetLocation()
        {
            CurrentLocation = await LocationService.GetCurrentLocation();
        }
    }
}


