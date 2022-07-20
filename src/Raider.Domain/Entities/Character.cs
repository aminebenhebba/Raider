using Raider.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Raider.Domain.Entities
{
    public class Character
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ClassId { get; set; }
        public bool IsMain { get; set; }
        public bool IsSaved { get; set; }

        public Class Class { get; set; } 
    }
}