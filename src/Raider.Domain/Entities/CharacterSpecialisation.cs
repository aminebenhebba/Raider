using System;

namespace Raider.Domain.Entities
{
    public class CharacterSpecialisation
    {
        public Guid CharacterId { get; set; }
        public string SpecialisationId { get; set; }
        public float? GearScore { get; set; }

        public Character Character { get; set; }
        public Specialisation Specialisation { get; set; }
    }
}