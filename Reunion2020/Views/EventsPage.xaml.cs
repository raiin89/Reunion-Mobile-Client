using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Reunion2020.View;
using Reunion2020.ViewModel;
using Reunion2020.Models;
using Reunion2020.Services;

namespace Reunion2020.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventsPage : ContentPage
    {
        EventViewModel eventsViewModel;


        public EventsPage()
        {

            InitializeComponent();
            eventsViewModel = new EventViewModel();
            BindingContext = eventsViewModel;
        }
    }
}
