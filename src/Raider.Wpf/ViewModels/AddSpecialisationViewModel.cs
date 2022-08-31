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
    public class AddSpecialisationViewModel: ViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly IDataService<Class> _classDataService;
        private readonly IDataService<Role> _roleDataService;

        private string? _specialisationName;
        public string? SpecialisationName
        {
            get { return _specialisationName; }
            set
            {
                _specialisationName = value;
                OnPropertyChange(nameof(SpecialisationName));
            }
        }

        private string? _specialisationIcon;
        public string? SpecialisationIcon
        {
            get { return _specialisationIcon; }
            set
            {
                _specialisationIcon = value;
                OnPropertyChange(nameof(SpecialisationIcon));
            }
        }

        private string? _class;
        public string? Class
        {
            get { return _class; }
            set
            {
                _class = value;
                OnPropertyChange(nameof(Class));
            }
        }

        private string? _role;
        public string? Role
        {
            get { return _role; }
            set
            {
                _role = value;
                OnPropertyChange(nameof(Role));
            }
        }

        private ObservableCollection<string> _classList;
        public ObservableCollection<string> ClassList
        {
            get { return _classList; }
            set
            {
                _classList = value;
                OnPropertyChange(nameof(ClassList));
            }
        }

        private ObservableCollection<string> _roleList;
        public ObservableCollection<string> RoleList
        {
            get { return _roleList; }
            set
            {
                _roleList = value;
                OnPropertyChange(nameof(RoleList));
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

        public ICommand CreateSpecialisationCommand { get; }
        public ICommand CancelCreateCommand { get; }

        public AddSpecialisationViewModel(INavigator navigator,
                                          IDataService<Specialisation> specialisationDataService,
                                          IDataService<Class> classDataService,
                                          IDataService<Role> roleDataService)
        {
            _navigator = navigator;
            _classDataService = classDataService;
            _roleDataService = roleDataService;

            var lisOfIcon = LoadSpecialisationIconList();
            if (lisOfIcon.Any())
            {
                IconList = new ObservableCollection<string>(lisOfIcon);
                SpecialisationIcon = IconList[0];
            }

            var listOfClasses = LoadClassesList();
            if (listOfClasses.Any())
            {
                ClassList = new ObservableCollection<string>(listOfClasses);
                Class = ClassList[0];
            }

            var listOfRoles = LoadRolesList();
            if (listOfRoles.Any())
            {
                RoleList = new ObservableCollection<string>(listOfRoles);
                Role = RoleList[0];
            }

            CancelCreateCommand = new NavigateCommand<SpecialisationsViewModel>(new NavigationService<SpecialisationsViewModel>(_navigator, () => new SpecialisationsViewModel(_navigator, specialisationDataService, classDataService, roleDataService)));
            CreateSpecialisationCommand = new CreateSpecialisationCommand(new NavigationService<SpecialisationsViewModel>(navigator, () => new SpecialisationsViewModel(_navigator, specialisationDataService, classDataService, roleDataService)), this, specialisationDataService);
        }

        private List<string>? LoadSpecialisationIconList()
        {
            var result = new List<string>(Directory.EnumerateFiles("./Resources/Specialisations").Select(file => Path.GetFileName(file)));

            return result;
        }

        private List<string>? LoadClassesList()
        {
            return _classDataService.GetAll().Select(c=>c.Id).ToList();
        }

        private List<string>? LoadRolesList()
        {
            return _roleDataService.GetAll().Select(r => r.Id).ToList();
        }
    }
}