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
        public ICommand AddClassCommand { get; }
        public ICommand DeleteClassCommand { get; }
        public Class SelectedItem { get; set; }

        public ObservableCollection<Class>? Classes { get; set; }

        public ClassesViewModel(NavigationStore navigationStore, IDataService<Class> classDataService)
        {
            Classes = new ObservableCollection<Class>(classDataService.GetAll());

            AddClassCommand = new NavigateCommand<AddClassViewModel>(new NavigationService<AddClassViewModel>(navigationStore, () => new AddClassViewModel(navigationStore, classDataService)));
            DeleteClassCommand = new DeleteClassCommand(this, classDataService);
        }
    }
}