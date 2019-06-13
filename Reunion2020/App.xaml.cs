using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Reunion2020.Views;
using Syncfusion.ListView.XForms;

namespace Reunion2020
{
    public partial class App : Application
    {
        SfListView listView;

        public App()
        {

            InitializeComponent();


            MainPage = new NavigationPage(new SplashPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
