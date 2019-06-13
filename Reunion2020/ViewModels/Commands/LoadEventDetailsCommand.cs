using System;
using System.Windows.Input;
using Reunion2020.Models;
namespace Reunion2020.ViewModels.Commands
{

    public class LoadEventDetailsCommand : ICommand
    {
        public EventDetailsViewModel EventDetailsViewModel {get;set;}

        public LoadEventDetailsCommand( EventDetailsViewModel vm)
        {
            this.EventDetailsViewModel = vm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            Event eventDetails = (Event)parameter;

            if (eventDetails != null)
                return true;
            else return false;   
         }

        public void Execute(object parameter)
        {
            Event eventDetails = (Event)parameter;
            EventDetailsViewModel.Navigate(eventDetails);
        }
    }
}
