using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Reunion2020.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace Reunion2020.Services
{
    // This service is to communicate with Google Geocoding API
    public class LocationGeocodingService
    {
        private const string GeoCodingGoogleAPI = "https://maps.googleapis.com/maps/api/geocode/json?address=";
        private const string APIKey = "&key=AIzaSyATOSEhbKfqV-ljH1PkKHN1KMjYZuMq9fs";


        // Reformat the address to the required Google API format
        private static string FormatAddressToLocate(string address, string zip, string city)
        {
            return (address + "+" + zip + ",+" + city + "+" + "DK");

        }

        // Gets the LocationGeocoding of the event
        public async static Task<LocationGeocoding> GetLocationForEvent(Event Event)
        {
            List<LocationGeocoding> locations = new List<LocationGeocoding>();

            try
            {
                string fullAdress = FormatAddressToLocate(
                    Event.Location.Address, Event.Location.Zip,
                    Event.Location.City);

                string fullRequestUrl = GeoCodingGoogleAPI + fullAdress + APIKey;


                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(fullRequestUrl);
                    var json = await response.Content.ReadAsStringAsync();
                    var locationRoot = JsonConvert.DeserializeObject<LocationGeocodingRoot>(json);
                    locations = locationRoot.results as List<LocationGeocoding>;
                }
                return locations[0];

            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", e.Message, "Ok");

            }

            return locations[0];




        }
    }
}
