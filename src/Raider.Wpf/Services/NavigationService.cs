using Raider.Wpf.Store;
using Raider.Wpf.ViewModels;
using System;

namespace Raider.Wpf.Services
{
    public class NavigationService<TViewModel> where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;

        public NavigationService(NavigationStore navigatorStore, Func<TViewModel> createViewModel)
        {
            _navigationStore = navigatorStore;
            _createViewModel = createViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}