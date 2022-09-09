using Raider.Domain.Enums;
using System;

namespace Raider.Domain.Entities
{
    public class Event
    {
        public Day Day { get; set; }
        public int EventId { get; set; }
        public string RaidId { get; set; }
        public Guid CharacterId { get; set; }
        public Guid RaidSetupId { get; set; }

        public Raid Raid { get; set; }
        public Character Character { get; set; }
        public RaidSetup RaidSetup { get; set; }
    }
}