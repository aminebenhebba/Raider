using Raider.Domain.Entities;
using Raider.Wpf.Commands;
using Raider.Wpf.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;

namespace Raider.Wpf.ViewModels
{
    public class AddRaidViewModel : ViewModelBase
    {
        private string? _raidName;
        public string? RaidName
        {
            get { return _raidName; }
            set
            {
                _raidName = value;
                OnPropertyChange(nameof(RaidName));
            }
        }

        private int _raidPLayers;
        public int RaidPlayers
        {
            get { return _raidPLayers; }
            set
            {
                _raidPLayers = value;
                OnPropertyChange(nameof(RaidPlayers));
            }
        }

        private int _raidPLayersPerGroup;
        public int RaidPlayersPerGroup
        {
            get { return _raidPLayersPerGroup; }
            set
            {
                _raidPLayersPerGroup = value;
                OnPropertyChange(nameof(RaidPlayersPerGroup));
            }
        }

        private string? _raidLogo;
        public string? RaidLogo
        {
            get { return _raidLogo; }
            set
            {
                _raidLogo = value;
                OnPropertyChange(nameof(RaidLogo));
            }
        }

        private ObservableCollection<string> _logoList;
        public ObservableCollection<string> LogoList
        {
            get { return _logoList; }
            set
            {
                _logoList = value;
                OnPropertyChange(nameof(LogoList));
            }
        }

        public ICommand CreateRaidCommand { get; }
        public ICommand CancelCreateCommand { get; }

        public AddRaidViewModel(NavigationService<RaidsViewModel> navigationService, IDataService<Raid> raidDataService)
        {
            var lisOfLogo = LoadRaidLogoList();

            if (lisOfLogo.Any())
            {
                LogoList = new ObservableCollection<string>(lisOfLogo);
                RaidLogo = LogoList[0];
            }

            CancelCreateCommand = new NavigateCommand<RaidsViewModel>(navigationService);

            CreateRaidCommand = new CreateRaidCommand(navigationService, this, raidDataService);
        }

        private List<string>? LoadRaidLogoList()
        {
            var result = new List<string>(Directory.EnumerateFiles("./Resources/Raids").Select(file => Path.GetFileName(file)));

            return result;
        }
    }
}
