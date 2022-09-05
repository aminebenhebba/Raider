using Raider.Domain.Entities;
using Raider.Wpf.Commands;
using Raider.Wpf.Services;
using Raider.Wpf.Store;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Raider.Wpf.ViewModels
{
    public class RaidsViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly IDataService<Raid> _raidDataService;
        public ICommand AddRaidCommand { get; }
        public ICommand DeleteRaidCommand { get; }
        public Raid SelectedItem { get; set; }

        public ObservableCollection<Raid>? Raids { get; set; }

        public RaidsViewModel(INavigator navigator, IDataService<Raid> raidDataService)
        {
            _navigator = navigator;
            _raidDataService = raidDataService;

            Raids = new ObservableCollection<Raid>(_raidDataService.GetAll());

            AddRaidCommand = new NavigateCommand<AddRaidViewModel>(new NavigationService<AddRaidViewModel>(_navigator, () => new AddRaidViewModel(_navigator, raidDataService)));
            DeleteRaidCommand = new DeleteRaidCommand(this, raidDataService);
        }
    }
}