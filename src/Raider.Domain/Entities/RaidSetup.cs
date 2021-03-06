using System;

namespace Raider.Domain.Entities
{
    public class RaidSetup
    {
        public Guid Id { get; set; }
        public Guid RaidId { get; set; }
        public string Name { get; set; }
        public string? Template { get; set; }

        public Raid Raid { get; set; }
    }
}