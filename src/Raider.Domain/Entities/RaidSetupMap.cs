using System;

namespace Raider.Domain.Entities
{
    public class RaidSetupMap
    {
        public Guid RaidSetupId { get; set; }
        public string SpecialisationId { get; set; }
        public int Group { get; set; }
        public int Index { get; set; }

        public RaidSetup RaidSetup { get; set; }
        public Specialisation Specialisation { get; set; }
    }
}