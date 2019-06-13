using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using Xamarin.Forms;
namespace Reunion2020.Models
{

    public class Location : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        [JsonProperty("address")]
        private string address;
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                onPropertyChanged("Address");
            }
        }

        [JsonProperty("zip")]
        private string zip;
        public string Zip
        {
            get { return zip; }
            set
            {
                zip = value;
                onPropertyChanged("Zip");
            }
        }

        [JsonProperty("city")]
        private string city;
        public string City
        {
            get { return city; }
            set
            {
                city = value;
                onPropertyChanged("City");
            }
        }

        private void onPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Arranger : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        [JsonProperty("name")]
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set { name = value; onPropertyChanged("Name"); }
        }
        [JsonProperty("email")]
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value; onPropertyChanged("Email");
            }
        }

        [JsonProperty("phone")]
        private string phone;
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value; onPropertyChanged("Phone");
            }
        }
        private void onPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }

    public class Event : INotifyPropertyChanged
    {

        [JsonProperty("location")]
        private Location location;
        public Location Location
        {
            get { return location; }
            set { location = value; onPropertyChanged("Location"); }
        }

        [JsonProperty("arranger")]
        private Arranger arranger;
        public Arranger Arranger
        {
            get
            { return arranger; }
            set { arranger = value; onPropertyChanged("Arranger"); }
        }


        [JsonProperty("timings")]
        private IList<DateTime> timings;
        public IList<DateTime> Timings
        {
            get { return timings; }
            set { timings = value; onPropertyChanged("Timings"); }
        }


        [JsonProperty("price")]
        private int price;
        public int Price
        {
            get
            { return price; }
            set { price = value; onPropertyChanged("Price"); }
        }


        [JsonProperty("links")]
        private IList<string> links;
        public IList<string> Links
        {
            get
            { return links; }
            set { links = value; onPropertyChanged("Links"); }
        }


        [JsonIgnore]
        private Image image;
        public Image Image
        {
            get { return image; }
            set { image = value; onPropertyChanged("Image"); }
        }


        [JsonProperty("images")]
        private IList<string> imagesBase64;
        public IList<string> ImagesBase64
        {
            get { return imagesBase64; }
            set { imagesBase64 = value; onPropertyChanged("ImageBase64"); }
        }


        [JsonProperty("_id")]
        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; onPropertyChanged("Id"); }
        }

        [JsonProperty("name")]
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; onPropertyChanged("Name"); }
        }


        [JsonProperty("description")]
        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; onPropertyChanged("Description"); }
        }


        [JsonProperty("targetGroup")]
        private string targetGroup;
        public string TargetGroup
        {
            get { return targetGroup; }
            set { targetGroup = value; onPropertyChanged("TargetGroup"); }
        }

        [JsonProperty("eventType")]
        private string eventType;
        public string EventType
        {
            get { return eventType; }
            set { eventType = value; onPropertyChanged("EventType"); }
        }


        [JsonProperty("eventCatagory")]
        private string eventCatagory;
        public string EventCatagory
        {
            get { return eventCatagory; }
            set { eventCatagory = value; onPropertyChanged("EventCatagory"); }
        }


        [JsonProperty("approvalStatus")]
        private string approvalStatus;
        public string ApprovalStatus
        {
            get { return approvalStatus; }
            set { approvalStatus = value; onPropertyChanged("ApprovalStatus"); }
        }


        [JsonProperty("createdAt")]
        private DateTime createdAt;
        public DateTime CreatedAt
        {
            get { return createdAt; }
            set { createdAt = value; onPropertyChanged("CreatedAt"); }
        }




        public event PropertyChangedEventHandler PropertyChanged;

        private void onPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Eventroot
    {

        [JsonProperty("data")]
        public IList<Event> Data { get; set; }
    }







}
