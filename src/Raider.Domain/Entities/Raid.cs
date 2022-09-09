using System;

namespace Raider.Domain.Entities
{
    public class Raid
    {
        public string Id { get; set; }
        public int Players { get; set; }
        public int PlayersPerGroup { get; set; }
        public string? Logo { get; set; }
    }
}