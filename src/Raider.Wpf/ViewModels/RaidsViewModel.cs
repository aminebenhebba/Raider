using Raider.Domain.Entities;
using Raider.Wpf.Commands;
using Raider.Wpf.Services;
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

        public RaidsViewModel(NavigationService<AddRaidViewModel> navigationService, IDataService<Raid> raidDataService)
        {
            Raids = new ObservableCollection<Raid>(raidDataService.GetAll());

            AddRaidCommand = new NavigateCommand<AddRaidViewModel>(navigationService);
            DeleteRaidCommand = new DeleteRaidCommand(this, raidDataService);
        }
    }
}