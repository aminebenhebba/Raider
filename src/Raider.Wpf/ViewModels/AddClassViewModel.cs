using Raider.Domain.Entities;
using Raider.Wpf.Commands;
using Raider.Wpf.Services;
using Raider.Wpf.Store;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;

namespace Raider.Wpf.ViewModels
{
    public class AddClassViewModel : ViewModelBase
    {
        private string? _className;
        public string? ClassName
        {
            get { return _className; }
            set
            {
               _className = value;
                OnPropertyChange(nameof(ClassName));
            }
        }

        private string? _classIcon;
        public string? ClassIcon
        {
            get { return _classIcon; }
            set
            {
                _classIcon = value;
                OnPropertyChange(nameof(ClassIcon));
            }
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

        private ObservableCollection<string> _iconList;
        public ObservableCollection<string> IconList
        {
            get { return _iconList; }
            set
            {
                _iconList = value;
                OnPropertyChange(nameof(IconList));
            }
        }

        public ICommand CreateClassCommand { get; }
        public ICommand CancelCreateCommand { get; }

        public AddClassViewModel(NavigationStore navigationStore, IDataService<Class> classDataService)
        {
            var lisOfIcon = LoadClassIconList();

            if (lisOfIcon.Any())
            {
                IconList = new ObservableCollection<string>(lisOfIcon);
                ClassIcon = IconList[0];
            }

            CancelCreateCommand = new NavigateCommand<ClassesViewModel>(new NavigationService<ClassesViewModel>(navigationStore, () => new ClassesViewModel(navigationStore, classDataService)));

            CreateClassCommand = new CreateClassCommand(new NavigationService<ClassesViewModel>(navigationStore, () => new ClassesViewModel(navigationStore, classDataService)), this, classDataService);
        }

        private List<string>? LoadClassIconList()
        {
            var result = new List<string>(Directory.EnumerateFiles("./Resources/Classes").Select(file => Path.GetFileName(file)));

            return result;
        }
    }
}