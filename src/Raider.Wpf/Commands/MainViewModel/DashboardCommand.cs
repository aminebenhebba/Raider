using Raider.Wpf.Store;
using Raider.Wpf.ViewModels;

namespace Raider.Wpf.Commands.MainViewModel
{
    public class DashboardCommand : CommandBase
    {
        private readonly INavigator _navigator;

        public DashboardCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public override void Execute(object? parameter)
        {
            _navigator.CurrentViewModel = new DashboardViewModel();
        }
    }
}