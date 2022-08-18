using Raider.Wpf.Commands;
using Raider.Wpf.Services;
using Raider.Wpf.Store;
using System.Windows.Input;

namespace Raider.Wpf.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;

        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;
        
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

        public MainViewModel(INavigator navigator, IClassDataService classDataService)
        {
            _navigator = navigator;

            _navigator.CurrentViewModelChanged += OnCurrentModelViewChanged;

            DashboardCommand = new NavigateCommand<DashboardViewModel>(new NavigationService<DashboardViewModel>(_navigator, () => new DashboardViewModel()));
            EventsCommand = new NavigateCommand<EventsViewModel>(new NavigationService<EventsViewModel>(_navigator, () => new EventsViewModel()));
            MembersCommand = new NavigateCommand<MembersViewModel>(new NavigationService<MembersViewModel>(_navigator, () => new MembersViewModel()));
            ClassesCommand = new NavigateCommand<ClassesViewModel>(new NavigationService<ClassesViewModel>(_navigator, () => new ClassesViewModel(_navigator, classDataService)));
            SpecialisationsCommand = new NavigateCommand<SpecialisationsViewModel>(new NavigationService<SpecialisationsViewModel>(_navigator, () => new SpecialisationsViewModel()));
            RolesCommand = new NavigateCommand<RolesViewModel>(new NavigationService<RolesViewModel>(_navigator, () => new RolesViewModel()));
            RaidsCommand = new NavigateCommand<RaidsViewModel>(new NavigationService<RaidsViewModel>(_navigator, () => new RaidsViewModel()));
            SetupsCommand = new NavigateCommand<SetupsViewModel>(new NavigationService<SetupsViewModel>(_navigator, () => new SetupsViewModel()));

            ExitCommand = new ExitCommand();
        }

        private void OnCurrentModelViewChanged()
        {
            OnPropertyChange(nameof(CurrentViewModel));
        }
    }
}