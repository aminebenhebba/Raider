using Raider.Domain.Entities;
using Raider.Wpf.Services;
using Raider.Wpf.ViewModels;

namespace Raider.Wpf.Commands
{
    public class DeleteRaidCommand : CommandBase
    {
        private readonly RaidsViewModel _raidViewModel;
        private readonly IDataService<Raid> _raidDataService;

        public DeleteRaidCommand(RaidsViewModel raidsViewModel, IDataService<Raid> raidDataService)
        {
            _raidViewModel = raidsViewModel;
            _raidDataService = raidDataService;
        }

        public override void Execute(object? parameter)
        {
            if (_raidViewModel.SelectedItem != null)
            {
                _raidDataService.Delete(_raidViewModel.SelectedItem);
                _raidDataService.SaveChanges();

                _raidViewModel.Raids?.Remove(_raidViewModel.SelectedItem);
            }
        }
    }
}
