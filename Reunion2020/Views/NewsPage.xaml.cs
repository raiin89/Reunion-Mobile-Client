using System;
using System.Collections.Generic;
using System.IO;
using Reunion2020.ViewModels.Commands;
using Reunion2020.ViewModels;

using Reunion2020.Services;


using Xamarin.Forms;

namespace Reunion2020.View
{
    public partial class NewsPage : ContentPage
    {
        NewsViewModel newsViewModel;
        public NewsPage()
        {

            InitializeComponent();
            newsViewModel = new NewsViewModel();
            BindingContext = newsViewModel;


        }

    

       




    }
}
