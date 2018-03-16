﻿using Prism;
using Prism.Ioc;
using WeatherMapApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using Prism.Navigation;
using System.Threading.Tasks;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace WeatherMapApp
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync<ForecastPage>();  
        }
        
        protected override void RegisterTypes( IContainerRegistry containerRegistry )
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<WeatherPage>();
            containerRegistry.RegisterForNavigation<CurrentWeatherPage>();
            containerRegistry.RegisterForNavigation<ForecastPage>();
        }
    }

    public static class NavigationExtension
    {
        public static async Task NavigateAsync<T>( this INavigationService navigationService )
        {
            await navigationService.NavigateAsync(typeof(T).Name);
        }
    }
}
