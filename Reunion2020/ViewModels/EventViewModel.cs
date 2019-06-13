using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Reunion2020.Models;
using Reunion2020.Services;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;

using System.Collections.ObjectModel;
using Reunion2020.ViewModels.Commands;

namespace Reunion2020.ViewModel
{
    public class EventViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public LoadEventsCommand LoadEventsCommand { get; set; }

        private ObservableCollection<Event> events;
        public ObservableCollection<Event> Events
        {
            get
            {
                return events;
            }
            set { events = value; onPropertyChanged("Events"); }
        }

        private void onPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        public EventViewModel()         {
            LoadEventsCommand = new LoadEventsCommand(this);
            try
            {
                Events = new ObservableCollection<Event>();
                 EventService.GetApprovedEvents(list =>
                {
                    foreach (Event item in list)
                    {
                        Events.Add(item);
                    }
                });

            } catch (Exception e)
            {
                Application.Current.MainPage.DisplayAlert("Something went wrong", e.Message, "Ok");

            }

        }

        public async void GetEventsAsync()
        {
            try
            {
                Events = new ObservableCollection<Event>();
                await EventService.GetApprovedEvents(list =>
                {
                    foreach (Event item in list)
                        Events.Add(item);
                });


            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Something went wrong", e.Message, "Ok");

            }
        }


    }

}


