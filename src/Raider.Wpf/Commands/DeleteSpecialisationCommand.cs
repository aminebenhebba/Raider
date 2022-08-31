using Raider.Domain.Entities;
using Raider.Wpf.Services;
using Raider.Wpf.ViewModels;

namespace Raider.Wpf.Commands
{
    public class DeleteSpecialisationCommand : CommandBase
    {
        private readonly SpecialisationsViewModel _specialisationsViewModel;
        private readonly IDataService<Specialisation> _specialisationDataService;

        public DeleteSpecialisationCommand(SpecialisationsViewModel specialisationsViewModel, IDataService<Specialisation> specialisationDataService)
        {
            _specialisationsViewModel = specialisationsViewModel;
            _specialisationDataService = specialisationDataService;
        }

        public override void Execute(object? parameter)
        {
            if (_specialisationsViewModel.SelectedItem != null)
            {
                _specialisationDataService.Delete(_specialisationsViewModel.SelectedItem);
                _specialisationDataService.SaveChanges();

                _specialisationsViewModel.Specialisations?.Remove(_specialisationsViewModel.SelectedItem);
            }
        }
    }
}
