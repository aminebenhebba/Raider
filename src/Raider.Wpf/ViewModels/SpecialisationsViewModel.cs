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
        private readonly INavigator _navigator;
        private readonly IDataService<Specialisation> _specialisationDataService;
        public ICommand AddSpecialisationCommand { get; }
        public ICommand DeleteSpecialisationCommand { get; }

        public Specialisation SelectedItem { get; set; }
        public ObservableCollection<Specialisation>? Specialisations { get; set; }

        public SpecialisationsViewModel(INavigator navigator,
                                        IDataService<Specialisation> specialisationDataService,
                                        IDataService<Class> classDataService,
                                        IDataService<Role> roleDataService)
        {
            _navigator = navigator;
            _specialisationDataService = specialisationDataService;

            Specialisations = new ObservableCollection<Specialisation>(_specialisationDataService.GetAll());

            AddSpecialisationCommand = new NavigateCommand<AddSpecialisationViewModel>(new NavigationService<AddSpecialisationViewModel>(_navigator, () => new AddSpecialisationViewModel(_navigator, specialisationDataService,classDataService,roleDataService)));
            DeleteSpecialisationCommand = new DeleteSpecialisationCommand(this, specialisationDataService);
        }
    }
}