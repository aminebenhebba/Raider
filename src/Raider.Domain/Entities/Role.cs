using System.Collections.Generic;

namespace Raider.Domain.Entities
{
    public class Role
    {
        public string Id { get; set; }
        public string? Icon { get; set; }

        public ICollection<Specialisation> Specialisations { get; set; }
    }
}