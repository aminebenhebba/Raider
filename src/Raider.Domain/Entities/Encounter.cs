using Raider.Domain.Enums;
using System;

namespace Raider.Domain.Entities
{
    public class Encounter
    {
        public Day Day { get; set; }
        public Guid RaidId { get; set; }
        public Guid CharacterId { get; set; }
        public Guid RaidSetupId { get; set; }

        public Raid Raid { get; set; }
        public Character Character { get; set; }
        public RaidSetup RaidSetup { get; set; }
    }
}