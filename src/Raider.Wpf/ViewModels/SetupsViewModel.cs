using Raider.Domain.Entities;
using Raider.Wpf.Commands;
using Raider.Wpf.Models;
using Raider.Wpf.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Raider.Wpf.ViewModels
{
    public class SetupsViewModel : ViewModelBase
    {
        private readonly IRaidSetupMapDataService _raidSetupMapDataService;
        private readonly IRaidDataService _raidDataService;

        private RaidSetup _selectedItem;
        public RaidSetup SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                RaidTemplate = GetRaidTemplate(_selectedItem);
                OnPropertyChange(nameof(SelectedItem));
            }
        }

        private RaidTemplate _raidTemplate;
        public RaidTemplate RaidTemplate
        {
            get { return _raidTemplate; }
            set
            {
                _raidTemplate = value;
                OnPropertyChange(nameof(RaidTemplate));
            }
        }

        public ObservableCollection<RaidSetup>? RaidSetups { get; set; }

        public ICommand AddRaidSetupCommand { get; }
        public ICommand DeleteRaidSetupCommand { get; }

        private RaidTemplate GetRaidTemplate(RaidSetup raidSetup)
        {
            if (raidSetup == null) return null;

            var raid = _raidDataService.Get(raidSetup.RaidId);

            var raidTemplate = new RaidTemplate
            {
                Id = raidSetup.Id,
                Name = raidSetup.Name,
                RaidId = raid.Id,
                Raid = raid,
                Groups = GetRaidTemplateGroups(raidSetup)
            };

            return raidTemplate;
        }

        private IEnumerable<Group> GetRaidTemplateGroups(RaidSetup raidSetup)
        {
            var raidGroups = new List<Group>();

            var raidTemplateGroups = _raidSetupMapDataService.Get(raidSetup.Id)
                                                             .OrderBy(item=>item.Group)
                                                             .ThenBy(item=>item.Index)
                                                             .GroupBy(item => item.Group);


            foreach (var group in raidTemplateGroups)
            {
                var members = new List<Member>();

                foreach (var member in group)
                {
                    members.Add(new Member
                    {
                        Index = member.Index,
                        Specialisation =member.Specialisation
                    });
                }

                var raidGroup = new Group
                {
                    Index = group.Key,
                    Members = members
                };
                raidGroups.Add(raidGroup);
            }

            return raidGroups;
        }

        public SetupsViewModel(NavigationService<AddSetupViewModel> navigationService,
                               IDataService<RaidSetup> raidSetupDataService,
                               IRaidSetupMapDataService raidSetupMapDataService,
                               IRaidDataService raidDataService)
        {
            _raidSetupMapDataService = raidSetupMapDataService;
            _raidDataService = raidDataService;

            RaidSetups = new ObservableCollection<RaidSetup>(raidSetupDataService.GetAll());
            if (RaidSetups.Any())
            {
                SelectedItem = RaidSetups[0];
            }

            AddRaidSetupCommand = new NavigateCommand<AddSetupViewModel>(navigationService);
        }
    }
}