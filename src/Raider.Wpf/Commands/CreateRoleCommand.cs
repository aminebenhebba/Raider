using Raider.Domain.Entities;
using Raider.Wpf.Services;
using Raider.Wpf.ViewModels;
using System.ComponentModel;

namespace Raider.Wpf.Commands
{
    public class CreateRoleCommand: CommandBase
    {
        private readonly AddRoleViewModel _addRoleViewModel;
        private readonly IDataService<Role> _roleDataService;
        private readonly NavigationService<RolesViewModel> _navigationService;

        public CreateRoleCommand(NavigationService<RolesViewModel> navigationService, AddRoleViewModel addRoleViewModel, IDataService<Role> roleDataService)
        {
            _addRoleViewModel = addRoleViewModel;
            _roleDataService = roleDataService;
            _navigationService = navigationService;

            addRoleViewModel.PropertyChanged += OnViewModelPropertyChange;
        }

        public override bool CanExecute(object? parameter)
        {
            if (string.IsNullOrWhiteSpace(_addRoleViewModel.RoleName))
            {
                return false;
            }
            return base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            var newRole = new Role
            {
                Id = _addRoleViewModel.RoleName,
                Icon = _addRoleViewModel.RoleIcon,
            };
            _roleDataService.Add(newRole);
            _roleDataService.SaveChanges();

            _navigationService.Navigate();
        }

        private void OnViewModelPropertyChange(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_addRoleViewModel.RoleName))
            {
                OnCanExecuteChanged();
            }
        }
    }
}