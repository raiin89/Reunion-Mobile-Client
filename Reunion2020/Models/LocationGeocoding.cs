using System;
using System.Collections.Generic;
using Newtonsoft.Json;


//TO DO: MVVM here 
namespace Reunion2020.Models
{
    public class AddressComponent
    {

        [JsonProperty("long_name")]
        public string long_name { get; set; }

        [JsonProperty("short_name")]
        public string short_name { get; set; }

        [JsonProperty("types")]
        public IList<string> types { get; set; }
    }

    public class LocationGeo
    {

        [JsonProperty("lat")]
        public double lat { get; set; }

        [JsonProperty("lng")]
        public double lng { get; set; }
    }

    public class Northeast
    {

        [JsonProperty("lat")]
        public double lat { get; set; }

        [JsonProperty("lng")]
        public double lng { get; set; }
    }

    public class Southwest
    {

        [JsonProperty("lat")]
        public double lat { get; set; }

        [JsonProperty("lng")]
        public double lng { get; set; }
    }



    public class Geometry
    {

        [JsonProperty("location")]
        public LocationGeo locationGeo { get; set; }

        [JsonProperty("location_type")]
        public string location_type { get; set; }


    }


    public class LocationGeocoding
    {

        [JsonProperty("address_components")]
        public IList<AddressComponent> address_components { get; set; }

        [JsonProperty("formatted_address")]
        public string formatted_address { get; set; }

        [JsonProperty("geometry")]
        public Geometry geometry { get; set; }





    
    }

    public class LocationGeocodingRoot
    {

        [JsonProperty("results")]
        public IList<LocationGeocoding> results { get; set; }

       
    }




}
