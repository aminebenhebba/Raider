using Raider.Domain.Entities;
using Raider.Wpf.Commands;
using Raider.Wpf.Services;
using Raider.Wpf.Store;
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

        public SpecialisationsViewModel(NavigationStore navigationStore,
                                        IDataService<Specialisation> specialisationDataService,
                                        IDataService<Class> classDataService,
                                        IDataService<Role> roleDataService)
        {
            Specialisations = new ObservableCollection<Specialisation>(specialisationDataService.GetAll());

            AddSpecialisationCommand = new NavigateCommand<AddSpecialisationViewModel>(new NavigationService<AddSpecialisationViewModel>(navigationStore, () => new AddSpecialisationViewModel(navigationStore, specialisationDataService,classDataService,roleDataService)));
            DeleteSpecialisationCommand = new DeleteSpecialisationCommand(this, specialisationDataService);
        }
    }
}