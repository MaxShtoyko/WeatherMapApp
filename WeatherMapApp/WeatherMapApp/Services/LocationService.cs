using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
using WeatherMapApp.Data;

namespace WeatherMapApp.Services
{
    static public class LocationService
    {
        static public async Task<Location> GetLocation()
        {
            var position = await CrossGeolocator.Current.GetPositionAsync(TimeSpan.FromSeconds(10));

            return new Location()
            {
                Latitude = position.Latitude.ToString(),
                Longitude = position.Longitude.ToString()
            };
        }
    }
}
