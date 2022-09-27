using Raider.Domain.Entities;
using Raider.Wpf.Commands;
using Raider.Wpf.Services;
using Raider.Wpf.Store;
using System;
using System.Windows.Input;

namespace Raider.Wpf.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;

        public event Action? RequestClose;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        
        private string? _searchedMember;
        public string? SearchedMember
        {
            get { return _searchedMember; }
            set
            {
                _searchedMember = value;
                OnPropertyChange(nameof(SearchedMember));
            }
        }

        public ICommand SearchMemberCommand { get; }
        public ICommand SettingsCommand { get; }
        public ICommand ThemeCommand { get; }

        public ICommand DashboardCommand { get; }
        public ICommand EventsCommand { get; }
        public ICommand MembersCommand { get; }
        public ICommand ClassesCommand { get; }
        public ICommand SpecialisationsCommand { get; }
        public ICommand RolesCommand { get; }
        public ICommand RaidsCommand { get; }
        public ICommand SetupsCommand { get; }

        public ICommand ExitCommand { get; }

        public MainViewModel(NavigationStore navigationStore,
                             IDataService<Class> classDataService,
                             IDataService<Specialisation> specialisationDataService,
                             IDataService<Role> roleDataService,
                             IRaidDataService raidDataService,
                             IDataService<RaidSetup> raidSetupDataService,
                             IRaidSetupMapDataService raidSetupMapDataService)
        {
            _navigationStore = navigationStore;

            _navigationStore.CurrentViewModelChanged += OnCurrentModelViewChanged;

            DashboardCommand = new NavigateCommand<DashboardViewModel>(new NavigationService<DashboardViewModel>(_navigationStore, () => new DashboardViewModel()));
            EventsCommand = new NavigateCommand<EventsViewModel>(new NavigationService<EventsViewModel>(_navigationStore, () => new EventsViewModel()));
            MembersCommand = new NavigateCommand<MembersViewModel>(new NavigationService<MembersViewModel>(_navigationStore, () => new MembersViewModel()));
            ClassesCommand = new NavigateCommand<ClassesViewModel>(new NavigationService<ClassesViewModel>(_navigationStore, () => new ClassesViewModel(_navigationStore, classDataService)));
            SpecialisationsCommand = new NavigateCommand<SpecialisationsViewModel>(new NavigationService<SpecialisationsViewModel>(_navigationStore, () => new SpecialisationsViewModel(_navigationStore, specialisationDataService,classDataService,roleDataService)));
            RolesCommand = new NavigateCommand<RolesViewModel>(new NavigationService<RolesViewModel>(_navigationStore, () => new RolesViewModel(_navigationStore, roleDataService)));
            RaidsCommand = new NavigateCommand<RaidsViewModel>(new NavigationService<RaidsViewModel>(_navigationStore, () => new RaidsViewModel(_navigationStore, raidDataService)));
            SetupsCommand = new NavigateCommand<SetupsViewModel>(new NavigationService<SetupsViewModel>(_navigationStore, () => new SetupsViewModel(_navigationStore, raidSetupDataService, raidSetupMapDataService, raidDataService)));

            ExitCommand = new ExitCommand(this);
        }

        private void OnCurrentModelViewChanged()
        {
            OnPropertyChange(nameof(CurrentViewModel));
        }

        public void OnRequestClose()
        {
            RequestClose?.Invoke();
        }
    }
}