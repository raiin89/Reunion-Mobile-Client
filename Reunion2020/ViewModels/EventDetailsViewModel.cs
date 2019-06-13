using System;
using System.ComponentModel;
using Reunion2020.ViewModels.Commands;
using Reunion2020.Models;
using Reunion2020.Views;
using Reunion2020.View;

namespace Reunion2020.ViewModels
{
    public class EventDetailsViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private Event eventDetails;
        public Event EventDetails
        {
            get { return eventDetails; }
            set { eventDetails = value; onPropertyChanged("EventDetails"); }
        }
        public LoadEventDetailsCommand LoadEventDetailsCommand { get; set; }
        public EventDetailsViewModel()
        {
            LoadEventDetailsCommand = new LoadEventDetailsCommand(this);
        }

        private void onPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void Navigate(Event eventToNavigate)
        {
            await App.Current.MainPage.Navigation.PushAsync(new EventDetailsPage(eventToNavigate));
        }


    }
}
