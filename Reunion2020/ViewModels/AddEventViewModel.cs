using System;
using System.ComponentModel;
using Reunion2020.Models;

namespace Reunion2020.ViewModels
{
    // TO DO: Complete MVVM here
    public class AddEventViewModel : INotifyPropertyChanged
    {
        private Event eventForm;

        public event PropertyChangedEventHandler PropertyChanged;

        public Event EventForm
        {
            get { return this.eventForm; }
            set { this.eventForm = value; }
        }


        public AddEventViewModel()
        {
            this.eventForm = new Event();
        }
    }
}
