using Raider.Domain.Entities;
using Raider.Wpf.Services;
using Raider.Wpf.ViewModels;

namespace Raider.Wpf.Commands
{
    internal class DeleteClassCommand : CommandBase
    {
        private readonly ClassesViewModel _classesViewModel;
        private readonly IDataService<Class> _classDataService;

        public DeleteClassCommand(ClassesViewModel classesViewModel, IDataService<Class> classDataService)
        {
            _classesViewModel = classesViewModel;
            _classDataService = classDataService;
        }

        public override void Execute(object? parameter)
        {
            if (_classesViewModel.SelectedItem != null)
            {
                _classDataService.Delete(_classesViewModel.SelectedItem);
                _classDataService.SaveChanges();

                _classesViewModel.Classes?.Remove(_classesViewModel.SelectedItem);   
            }
        }
    }
}
