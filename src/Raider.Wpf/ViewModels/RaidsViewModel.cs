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
        public ICommand AddRaidCommand { get; }
        public ICommand DeleteRaidCommand { get; }
        public Raid SelectedItem { get; set; }

        public ObservableCollection<Raid>? Raids { get; set; }

        public RaidsViewModel(NavigationStore navigationStore, IDataService<Raid> raidDataService)
        {
            Raids = new ObservableCollection<Raid>(raidDataService.GetAll());

            AddRaidCommand = new NavigateCommand<AddRaidViewModel>(new NavigationService<AddRaidViewModel>(navigationStore, () => new AddRaidViewModel(navigationStore, raidDataService)));
            DeleteRaidCommand = new DeleteRaidCommand(this, raidDataService);
        }
    }
}