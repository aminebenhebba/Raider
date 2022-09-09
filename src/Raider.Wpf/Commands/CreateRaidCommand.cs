using Raider.Domain.Entities;
using Raider.Wpf.Services;
using Raider.Wpf.ViewModels;
using System;
using System.ComponentModel;

namespace Raider.Wpf.Commands
{
    public class CreateRaidCommand : CommandBase
    {
        private readonly AddRaidViewModel _addRaidViewModel;
        private readonly IDataService<Raid> _raidDataService;
        private readonly NavigationService<RaidsViewModel> _navigationService;

        public CreateRaidCommand(NavigationService<RaidsViewModel> navigationService, AddRaidViewModel addRaidViewModel, IDataService<Raid> raidDataService)
        {
            _navigationService = navigationService;
            _addRaidViewModel = addRaidViewModel;
            _raidDataService = raidDataService;

            _addRaidViewModel.PropertyChanged += OnViewModelPropertyChange;
        }

        public override bool CanExecute(object? parameter)
        {
            if (string.IsNullOrWhiteSpace(_addRaidViewModel.RaidName) ||
                // TODO: assuming that the number of players of a giving MMO dont goes under 5, and there is more then 1 player per group
                // ==> you sould probably push this to a settings !!!
                _addRaidViewModel.RaidPlayers < 5 || _addRaidViewModel.RaidPlayersPerGroup <= 1 )
            {
                return false;
            }
            return base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            var newRaid = new Raid
            {
                Id = _addRaidViewModel.RaidName,
                Players = _addRaidViewModel.RaidPlayers,
                PlayersPerGroup = _addRaidViewModel.RaidPlayersPerGroup,
                Logo = _addRaidViewModel.RaidLogo
            };
            _raidDataService.Add(newRaid);
            _raidDataService.SaveChanges();

            _navigationService.Navigate();
        }

        private void OnViewModelPropertyChange(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_addRaidViewModel.RaidName) ||
                e.PropertyName == nameof(_addRaidViewModel.RaidPlayers) ||
                e.PropertyName == nameof(_addRaidViewModel.RaidPlayersPerGroup))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
