using System;
using System.Collections.Generic;
using Plugin.Permissions;
using Xamarin.Forms;
using Plugin.Permissions.Abstractions;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms.Xaml;
using Reunion2020.Models;
using Reunion2020.Services;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Reunion2020.View
{
    // TO DO: Move to MapViewModel
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class MapPage : ContentPage
    {
        private bool hasLocationPermission = false;

        public MapPage()
        {
            InitializeComponent();

            GetPermissions();
        }

        // Getting the location permission from the user
        private async void GetPermissions()
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.LocationWhenInUse))
                    {
                        await DisplayAlert("Need your location", "We need to access your location", "Ok");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.LocationWhenInUse);
                    if (results.ContainsKey(Permission.LocationWhenInUse))
                        status = results[Permission.LocationWhenInUse];
                }

                if (status == PermissionStatus.Granted)
                {
                    hasLocationPermission = true;
                    locationsMap.IsShowingUser = true;

                    GetLocation();
                }
                else
                {
                    await DisplayAlert("Location denied", "You didn't give us permission to access location, so we can't show you where you are", "Ok");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }


        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            CrossGeolocator.Current.StopListeningAsync(); // To save battery
            CrossGeolocator.Current.PositionChanged -= Locator_PositionChanged; // Unsubscribing from the event

        }

        // Getting the user's location and moving the map to it
        private async void GetLocation()
        {
            if (hasLocationPermission)
            {
                var locator = CrossGeolocator.Current;
                var position = await locator.GetPositionAsync();

                MoveMap(position);
            }
        }

        // Handling Position Changed event
        void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            MoveMap(e.Position);
        }

        // Moving the map to the user's location
        private void MoveMap(Position position)
        {
            var center = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
            var span = new Xamarin.Forms.Maps.MapSpan(center, 1, 1);

            locationsMap.MoveToRegion(span);
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (hasLocationPermission)
            {
                var locator = CrossGeolocator.Current;

                locator.PositionChanged += Locator_PositionChanged;
                await locator.StartListeningAsync(TimeSpan.Zero, 100);
            }

            GetLocation();

            ObservableCollection<Event> events = new ObservableCollection<Event>();
            await EventService.GetApprovedEvents(list =>
            {
                foreach (Event item in list)
                {
                    events.Add(item);
                }
            });
        
            ObservableCollection<Event> upcomingEvents = await FilterUpcomingEvents(events);
            await DisplayPins(upcomingEvents); // Set the pins on Events locations

        }


        private async Task DisplayPins(ObservableCollection<Event> filteredEvents)
        {
            foreach (Event item in filteredEvents)
            {
                LocationGeocoding location = await LocationGeocodingService.GetLocationForEvent(item);
                double lat = location.geometry.locationGeo.lat;
                double lng = location.geometry.locationGeo.lng;

                var position = new Xamarin.Forms.Maps.Position(lat, lng);
                var pin = new Xamarin.Forms.Maps.Pin()
                {
                    Type = Xamarin.Forms.Maps.PinType.SavedPin,
                    Position = position,
                    Label = item.Name,
                    Address = item.Location.Address
                };

                locationsMap.Pins.Add(pin);

            }


        }


        // Filter events to get only the upcoming events
        private async Task<ObservableCollection<Event>> FilterUpcomingEvents(ObservableCollection<Event> events)
        {
            ObservableCollection<Event> upComings = new ObservableCollection<Event>();
                await EventService.GetApprovedEvents(list =>
                 {
                     foreach (Event item in list)
                     {
                         if (DateTime.Compare(item.Timings[0], DateTime.Now) >= 0 && DateTime.Compare(item.Timings[1], DateTime.Now) >= 0)
                         {
                             upComings.Add(item);
                         }

                     }
                 });

            return upComings;
           
        }

    }
}


