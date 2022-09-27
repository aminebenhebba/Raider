using Raider.Domain.Entities;
using Raider.Wpf.Commands;
using Raider.Wpf.Services;
using Raider.Wpf.Store;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;

namespace Raider.Wpf.ViewModels
{
    public class AddRoleViewModel: ViewModelBase
    {
        private string? _roleName;
        public string? RoleName
        {
            get { return _roleName; }
            set
            {
                _roleName = value;
                OnPropertyChange(nameof(RoleName));
            }
        }

        private string? _roleIcon;
        public string? RoleIcon
        {
            get { return _roleIcon; }
            set
            {
                _roleIcon = value;
                OnPropertyChange(nameof(RoleIcon));
            }
        }

        private ObservableCollection<string> _iconList;
        public ObservableCollection<string> IconList
        {
            get { return _iconList; }
            set
            {
                _iconList = value;
                OnPropertyChange(nameof(IconList));
            }
        }

        public ICommand CreateRoleCommand { get; }
        public ICommand CancelCreateCommand { get; }

        public AddRoleViewModel(NavigationStore navigationStore, IDataService<Role> roleDataService)
        {
            var lisOfIcon = LoadRoleIconList();

            if (lisOfIcon.Any())
            {
                IconList = new ObservableCollection<string>(lisOfIcon);
                RoleIcon = IconList[0];
            }

            CancelCreateCommand = new NavigateCommand<RolesViewModel>(new NavigationService<RolesViewModel>(navigationStore, () => new RolesViewModel(navigationStore, roleDataService)));

            CreateRoleCommand = new CreateRoleCommand(new NavigationService<RolesViewModel>(navigationStore, () => new RolesViewModel(navigationStore, roleDataService)), this, roleDataService);
        }


        private List<string>? LoadRoleIconList()
        {
            var result = new List<string>(Directory.EnumerateFiles("./Resources/Roles").Select(file => Path.GetFileName(file)));

            return result;
        }
    }
}