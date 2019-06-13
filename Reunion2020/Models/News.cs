using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace Reunion2020.Models

{
    public class NewsRoot
    {


        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("data")]
        public IList<News> Data { get; set; }
    }
    public class News : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void onPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
            set { imagesBase64 = value; onPropertyChanged("ImagesBase64"); }
        }

        [JsonProperty("links")]
        private IList<string> links;
        public IList<string> Links
        {
            get { return links; }
            set { links = value; onPropertyChanged("Links"); }
        }


        [JsonProperty("_id")]
        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        [JsonProperty("author")]
        private string author;
        public string Author
        {
            get { return author; }
            set { author = value; onPropertyChanged("Author"); }
        }

        [JsonProperty("headline")]
        private string headline;
        public string Headline
        {
            get
            { return headline; }
            set
            { headline = value; onPropertyChanged("Headline"); }
        }

        [JsonProperty("content")]
        private string content;
        public string Content
        {
            get { return content; }
            set
            { content = value; onPropertyChanged("Content"); }
        }



        [JsonProperty("publishDateTime")]
        private DateTime publishedDateTime;
        public DateTime PublishDateTime
        {
            get { return publishedDateTime; }
            set { publishedDateTime = value; onPropertyChanged("PublishedDateTime"); }
        }







    }





}

