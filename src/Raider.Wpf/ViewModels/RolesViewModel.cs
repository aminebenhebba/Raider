using Raider.Domain.Entities;
using Raider.Wpf.Services;
using Raider.Wpf.Store;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Raider.Wpf.ViewModels
{
    public class RolesViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly IDataService<Role> _roleDataService;
        public ICommand AddRoleCommand { get; }

        public ObservableCollection<Role>? Roles { get; set; }

        public RolesViewModel(INavigator navigator, IDataService<Role> roleDataService)
        {
            _navigator = navigator;
            _roleDataService = roleDataService;

            Roles = new ObservableCollection<Role>(_roleDataService.GetAll());
        }
    }
}