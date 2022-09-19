using Raider.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Raider.Wpf.Models
{
    public class RaidTemplate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string RaidId { get; set; }
        public IEnumerable<Group>  Groups { get; set; }
        public Raid Raid { get; set; }
    }
}