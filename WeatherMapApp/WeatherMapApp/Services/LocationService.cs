using System;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using WeatherMapApp.Models;

namespace WeatherMapApp.Services
{
    public static class LocationService
    {
        static public async Task<Location> GetCurrentLocation()
        {
            bool locationAllowed = await CheckPermission();

            if( locationAllowed ) {
                var position = await CrossGeolocator.Current.GetPositionAsync( TimeSpan.FromSeconds( 2 ) );
                return new Location() {
                    Latitude = position.Latitude.ToString(),
                    Longitude = position.Longitude.ToString()
                };
            }

            return new Location();

        }

        private static async Task<bool> CheckPermission()
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    {
                        //await _pageService.DisplayAlertAsync("Need location", "Gunna need that location", "OK");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                    //Best practice to always check that the key exists
                    if (results.ContainsKey(Permission.Location))
                        status = results[Permission.Location];
                }

                if (status == PermissionStatus.Granted)
                {
                    return true;
                }
                else if (status != PermissionStatus.Unknown)
                {
                    //await _pageService.DisplayAlertAsync("Location Denied", "Can not continue, try again.", "OK");
                }
            }
            catch (Exception ex)
            {

                // TO DO
            }

            return false;
        }
    }
}
