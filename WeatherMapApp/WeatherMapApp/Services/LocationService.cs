using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Geolocator;
using WeatherMapApp.Data;

namespace WeatherMapApp.Services
{
    static public class LocationService
    {
        static private Location currentLocation;

        static LocationService()
        {
            SetLocation();
        }

        static public Location GetLocation()
        {
            return currentLocation;
        }

        static private async void SetLocation()
        {
            var position = await CrossGeolocator.Current.GetPositionAsync(TimeSpan.FromSeconds(10));

            currentLocation = new Location()
            {
                Latitude = position.Latitude.ToString(),
                Longitude = position.Longitude.ToString()
            };
        }
    }
}
