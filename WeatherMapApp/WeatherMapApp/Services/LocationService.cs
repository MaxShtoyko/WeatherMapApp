﻿using System;
using System.Threading.Tasks;
using Plugin.Geolocator;
using WeatherMapApp.Models;

namespace WeatherMapApp.Services
{
    public class LocationService
    {
        static public async Task<Location> GetCurrentLocation()
        {
            var position = await CrossGeolocator.Current.GetPositionAsync(TimeSpan.FromSeconds(2));

            return new Location()
            {
                Latitude = position.Latitude.ToString(),
                Longitude = position.Longitude.ToString()
            };
        }
    }
}
