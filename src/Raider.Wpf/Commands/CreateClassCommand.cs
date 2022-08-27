using Raider.Domain.Entities;
using Raider.Wpf.Services;
using Raider.Wpf.ViewModels;
using System.ComponentModel;

namespace Raider.Wpf.Commands
{
    public class CreateClassCommand : CommandBase
    {
        private readonly AddClassViewModel _addClassViewModel;
        private readonly IDataService<Class> _classDataService;
        private readonly NavigationService<ClassesViewModel> _navigationService;

        public CreateClassCommand(NavigationService<ClassesViewModel> navigationService, AddClassViewModel addClassViewModel, IDataService<Class> classDataService)
        {
            _navigationService = navigationService;
            _addClassViewModel = addClassViewModel;
            _classDataService = classDataService;

            _addClassViewModel.PropertyChanged += OnViewModelPropertyChange;
        }

        public override bool CanExecute(object? parameter)
        {
            if (string.IsNullOrWhiteSpace(_addClassViewModel.ClassName) ||
                string.IsNullOrWhiteSpace(_addClassViewModel.ClassColor))
            {
                return false;
            }
            return base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            var newClass = new Class
            {
                Id = _addClassViewModel.ClassName,
                Icon =  _addClassViewModel.ClassIcon,
                Color = _addClassViewModel.ClassColor
            };
            _classDataService.Add(newClass);
            _classDataService.SaveChanges();

            _navigationService.Navigate();
        }

        private void OnViewModelPropertyChange(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_addClassViewModel.ClassName) ||
                e.PropertyName == nameof(_addClassViewModel.ClassColor))
            {
                OnCanExecuteChanged();
            }
        }

    }
}