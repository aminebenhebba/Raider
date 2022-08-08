using Raider.Wpf.Commands;
using Raider.Wpf.Commands.MainViewModel;
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

        public MainViewModel(INavigator navigator)
        {
            _navigator = navigator;

            _navigator.CurrentViewModelChanged += OnCurrentModelViewChanged;

            DashboardCommand = new DashboardCommand(_navigator);
            EventsCommand = new EventsCommand(_navigator);
            MembersCommand = new MembersCommand(_navigator);
            ClassesCommand = new ClassesCommand(_navigator);
            SpecialisationsCommand = new SpecialisationsCommand(_navigator);
            RolesCommand = new RolesCommand(_navigator);
            RaidsCommand = new RaidsCommand(_navigator);
            SetupsCommand = new SetupsCommand(_navigator);

            ExitCommand = new ExitCommand();
        }

        private void OnCurrentModelViewChanged()
        {
            OnPropertyChange(nameof(CurrentViewModel));
        }
    }
}