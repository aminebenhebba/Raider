using System;

namespace Raider.Domain.Entities
{
    public class Character
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ClassId { get; set; }
        public bool IsMain { get; set; }
        public Guid? MainId { get; set; }
        public bool IsSaved { get; set; }

        public Class Class { get; set; }
        public Character? Main { get; set; }
    }
}