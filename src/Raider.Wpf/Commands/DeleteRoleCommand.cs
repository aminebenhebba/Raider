using Raider.Domain.Entities;
using Raider.Wpf.Services;
using Raider.Wpf.ViewModels;

namespace Raider.Wpf.Commands
{
    public class DeleteRoleCommand : CommandBase
    {
        private readonly RolesViewModel _rolesViewModel;
        private readonly IDataService<Role> _roleDataService;

        public DeleteRoleCommand(RolesViewModel classesViewModel, IDataService<Role> roleDataService)
        {
            _rolesViewModel = classesViewModel;
            _roleDataService = roleDataService;
        }

        public override void Execute(object? parameter)
        {
            if (_rolesViewModel.SelectedItem != null)
            {
                _roleDataService.Delete(_rolesViewModel.SelectedItem);
                _roleDataService.SaveChanges();

                _rolesViewModel.Roles?.Remove(_rolesViewModel.SelectedItem);
            }
        }
    }
}
