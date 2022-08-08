using Raider.Wpf.Store;
using Raider.Wpf.ViewModels;
using System;

namespace Raider.Wpf.Services
{
    public class NavigationService<TViewModel> where TViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly Func<TViewModel> _createViewModel;

        public NavigationService(INavigator navigator, Func<TViewModel> createViewModel)
        {
            _navigator = navigator;
            _createViewModel = createViewModel;
        }

        public void Navigate()
        {
            _navigator.CurrentViewModel = _createViewModel();
        }
    }
}