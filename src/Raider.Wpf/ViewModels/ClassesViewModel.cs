using Raider.Domain.Entities;
using Raider.Wpf.Commands;
using Raider.Wpf.Services;
using Raider.Wpf.Store;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Raider.Wpf.ViewModels
{
    public class ClassesViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly IClassDataService _classDataService;
        public ICommand AddClassCommand { get; }
        public ICommand DeleteClassCommand { get; }
        public Class SelectedItem { get; set; }

        public ObservableCollection<Class>? Classes { get; set; }

        public ClassesViewModel(INavigator navigator, IClassDataService classDataService)
        {
            _navigator = navigator;
            _classDataService = classDataService;

            Classes = new ObservableCollection<Class>(_classDataService.GetAll());

            AddClassCommand = new NavigateCommand<AddClassViewModel>(new NavigationService<AddClassViewModel>(_navigator, () => new AddClassViewModel(_navigator, classDataService)));
            DeleteClassCommand = new DeleteClassCommand(this, classDataService);
        }
    }
}