using Raider.Domain.Enums;
using System;

namespace Raider.Domain.Entities
{
    public class Raid
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int PlayersCount { get; set; }
        public string? Logo { get; set; }
    }
}