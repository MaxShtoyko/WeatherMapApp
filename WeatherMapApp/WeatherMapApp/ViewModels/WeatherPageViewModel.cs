using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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
            CurrentLocation = await LocationService.GetLocation();
        }
    }
}


