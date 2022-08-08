using Raider.Wpf.Store;
using Raider.Wpf.ViewModels;

namespace Raider.Wpf.Commands.MainViewModel
{
    public class ClassesCommand : CommandBase
    {
        private readonly INavigator _navigator;

        public ClassesCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public override void Execute(object? parameter)
        {
            _navigator.CurrentViewModel = new ClassesViewModel();
        }
    }
}