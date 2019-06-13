using System;
using System.Collections.Generic;
using Reunion2020.Models;
using Reunion2020.ViewModels.Commands;
using Reunion2020.ViewModels;

using Xamarin.Forms;

namespace Reunion2020.View
{
    public partial class EventDetailsPage : ContentPage
    {

        public Event Event { get; set; }

        public EventDetailsPage(Event selectedEvent)
        {
            InitializeComponent();
            this.Event = selectedEvent;

        }
    }
}
