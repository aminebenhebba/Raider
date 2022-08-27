using Raider.Domain.Entities;
using Raider.Wpf.Commands;
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
        public ICommand DeleteRoleCommand { get; }
        public Role SelectedItem { get; set; }

        public ObservableCollection<Role>? Roles { get; set; }

        public RolesViewModel(INavigator navigator, IDataService<Role> roleDataService)
        {
            _navigator = navigator;
            _roleDataService = roleDataService;

            Roles = new ObservableCollection<Role>(_roleDataService.GetAll());

            AddRoleCommand = new NavigateCommand<AddRoleViewModel>(new NavigationService<AddRoleViewModel>(_navigator, () => new AddRoleViewModel(_navigator, roleDataService)));
            DeleteRoleCommand = new DeleteRoleCommand(this, roleDataService);
        }
    }
}