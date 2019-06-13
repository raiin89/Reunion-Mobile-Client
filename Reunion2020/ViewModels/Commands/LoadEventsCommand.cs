using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Reunion2020.ViewModel;
using Xamarin.Forms;
using Reunion2020.Models;
using Reunion2020.Services;

namespace Reunion2020.ViewModels.Commands
{
    public class LoadEventsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;


        public EventViewModel EventsViewModel { get; set; }

        public LoadEventsCommand(EventViewModel vm)
        {
            this.EventsViewModel = vm;
        }


        public bool CanExecute(object parameter)
        {
            return true;

        } 



        public void Execute(object parameter)
        {
            this.EventsViewModel.GetEventsAsync();

        }
    }
}
