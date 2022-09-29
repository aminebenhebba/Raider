using Raider.Domain.Entities;
using Raider.Wpf.Commands;
using Raider.Wpf.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Raider.Wpf.ViewModels
{
    public class ClassesViewModel : ViewModelBase
    {
        public ICommand AddClassCommand { get; }
        public ICommand DeleteClassCommand { get; }
        public Class SelectedItem { get; set; }

        public ObservableCollection<Class>? Classes { get; set; }

        public ClassesViewModel(NavigationService<AddClassViewModel> navigationService, IDataService<Class> classDataService)
        {
            Classes = new ObservableCollection<Class>(classDataService.GetAll());

            AddClassCommand = new NavigateCommand<AddClassViewModel>(navigationService);
            DeleteClassCommand = new DeleteClassCommand(this, classDataService);
        }
    }
}