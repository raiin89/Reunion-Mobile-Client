using System;
using System.Collections.Generic;
using Syncfusion.XForms.DataForm;
using Reunion2020.ViewModels;
using Reunion2020.ViewModel;
using Reunion2020.Models;

using Xamarin.Forms;

namespace Reunion2020.View
{
    public partial class AddEventPage : ContentPage
    {


      

        public AddEventPage()
        {
            InitializeComponent();
            BindingContext = new AddEventViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            dataForm.DataObject = new Event();

        }
    }
}
