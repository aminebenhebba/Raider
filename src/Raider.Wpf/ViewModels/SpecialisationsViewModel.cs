using Raider.Domain.Entities;
using Raider.Wpf.Services;
using Raider.Wpf.Store;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Raider.Wpf.ViewModels
{
    public class SpecialisationsViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly ISpecialisationDataService _specialisationDataService;
        public ICommand AddClassCommand { get; }

        public ObservableCollection<Specialisation>? Specialisations { get; set; }

        public SpecialisationsViewModel(INavigator navigator, ISpecialisationDataService specialisationDataService)
        {
            _navigator = navigator;
            _specialisationDataService = specialisationDataService;

            Specialisations = new ObservableCollection<Specialisation>(_specialisationDataService.GetAll());
        }
    }
}