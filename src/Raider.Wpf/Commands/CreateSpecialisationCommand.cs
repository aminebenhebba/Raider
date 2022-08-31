using Raider.Domain.Entities;
using Raider.Wpf.Services;
using Raider.Wpf.ViewModels;
using System.ComponentModel;

namespace Raider.Wpf.Commands
{
    public class CreateSpecialisationCommand : CommandBase
    {
        private readonly IDataService<Specialisation> _specialisationDataService;
        private readonly AddSpecialisationViewModel _addSpecialisationViewModel;
        private readonly NavigationService<SpecialisationsViewModel> _navigationService;

        public CreateSpecialisationCommand(NavigationService<SpecialisationsViewModel> navigationService,
                                           AddSpecialisationViewModel addSpecialisationViewModel,
                                           IDataService<Specialisation> specialisationDataService)
        {
            _navigationService = navigationService;
            _addSpecialisationViewModel = addSpecialisationViewModel;
            _specialisationDataService = specialisationDataService;

            _addSpecialisationViewModel.PropertyChanged += OnViewModelPropertyChange;
        }

        public override bool CanExecute(object? parameter)
        {
            if (string.IsNullOrWhiteSpace(_addSpecialisationViewModel.SpecialisationName))
            {
                return false;
            }
            return base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            var newClass = new Specialisation
            {
                Id = _addSpecialisationViewModel.SpecialisationName,
                ClassId = _addSpecialisationViewModel.Class,
                RoleId = _addSpecialisationViewModel.Role,
                Icon = _addSpecialisationViewModel.SpecialisationIcon
            };
            _specialisationDataService.Add(newClass);
            _specialisationDataService.SaveChanges();

            _navigationService.Navigate();
        }

        private void OnViewModelPropertyChange(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_addSpecialisationViewModel.SpecialisationName))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
