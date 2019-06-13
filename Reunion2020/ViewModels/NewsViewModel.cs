using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Reunion2020.Models;
using Reunion2020.Services;
using Reunion2020.ViewModels.Commands;

namespace Reunion2020.ViewModels
{
    public class NewsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public LoadNewsCommand LoadNewsCommand { get; set; }

        private ObservableCollection<News> news;
        public ObservableCollection<News> News
        {
            get { return news; }
            set { news = value; onPropertyChanged("News"); }
        }


        public NewsViewModel()
        {
            LoadNewsCommand = new LoadNewsCommand(this);
            GetNewsAsync();

        }

        public async void GetNewsAsync()
        {
            try
            {
                News = new ObservableCollection<News>();
                await NewsService.GetPublishedNews(list =>
                {
                    foreach (News item in list)
                        News.Add(item);
                });


            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Something went wrong", e.Message, "Ok");

            }
        }
            private void onPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

        }
}