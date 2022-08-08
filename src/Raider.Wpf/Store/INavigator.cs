using Raider.Wpf.ViewModels;
using System;

namespace Raider.Wpf.Store
{
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }

        public event Action CurrentViewModelChanged;
    }
}