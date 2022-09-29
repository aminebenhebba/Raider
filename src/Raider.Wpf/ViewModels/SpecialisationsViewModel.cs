using Raider.Domain.Entities;
using Raider.Wpf.Commands;
using Raider.Wpf.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Raider.Wpf.ViewModels
{
    public class SpecialisationsViewModel : ViewModelBase
    {
        public ICommand AddSpecialisationCommand { get; }
        public ICommand DeleteSpecialisationCommand { get; }

        public Specialisation SelectedItem { get; set; }
        public ObservableCollection<Specialisation>? Specialisations { get; set; }

        public SpecialisationsViewModel(NavigationService<AddSpecialisationViewModel> navigationService,
                                        IDataService<Specialisation> specialisationDataService)
        {
            Specialisations = new ObservableCollection<Specialisation>(specialisationDataService.GetAll());

            AddSpecialisationCommand = new NavigateCommand<AddSpecialisationViewModel>(navigationService);
            DeleteSpecialisationCommand = new DeleteSpecialisationCommand(this, specialisationDataService);
        }
    }
}