using Raider.Wpf.Store;
using Raider.Wpf.ViewModels;

namespace Raider.Wpf.Commands.MainViewModel
{
    public class EventsCommand : CommandBase
    {
        private readonly INavigator _navigator;

        public EventsCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public override void Execute(object? parameter)
        {
            _navigator.CurrentViewModel = new EventsViewModel();
        }
    }
}