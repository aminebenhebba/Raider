using Raider.Domain.Entities;
using Raider.Wpf.Commands;
using Raider.Wpf.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Raider.Wpf.ViewModels
{
    public class RolesViewModel : ViewModelBase
    {
        public ICommand AddRoleCommand { get; }
        public ICommand DeleteRoleCommand { get; }
        public Role SelectedItem { get; set; }

        public ObservableCollection<Role>? Roles { get; set; }

        public RolesViewModel(NavigationService<AddRoleViewModel> navigationService, IDataService<Role> roleDataService)
        {
            Roles = new ObservableCollection<Role>(roleDataService.GetAll());

            AddRoleCommand = new NavigateCommand<AddRoleViewModel>(navigationService);
            DeleteRoleCommand = new DeleteRoleCommand(this, roleDataService);
        }
    }
}