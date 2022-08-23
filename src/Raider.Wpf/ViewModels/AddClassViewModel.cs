using Raider.Wpf.Commands;
using Raider.Wpf.Services;
using Raider.Wpf.Store;
using System.Windows.Input;

namespace Raider.Wpf.ViewModels
{
    public class AddClassViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;

        private string? _className;
        public string? ClassName
        {
            get { return _className; }
            set { _className = value; }
        }

        private string? _classIcon;
        public string? ClassIcon
        {
            get { return _classIcon; }
            set { _classIcon = value; }
        }

        private string? _classColor;
        public string? ClassColor
        {
            get { return _classColor; }
            set
            {
                _classColor = value;
                OnPropertyChange(nameof(ClassColor));
            }
        }

        public ICommand CreateClassCommand { get; }
        public ICommand CancelCreateCommand { get; }

        public AddClassViewModel(INavigator navigator, IClassDataService classDataService)
        {
            _navigator = navigator;

            CancelCreateCommand = new NavigateCommand<ClassesViewModel>(new NavigationService<ClassesViewModel>(_navigator, () => new ClassesViewModel(_navigator, classDataService)));
        }
    }
}