using System.Collections.Generic;

namespace Raider.Domain.Entities
{
    public class Class
    {
        public string Id { get; set; }
        public string? Icon { get; set; }

        ICollection<Specialisation> Specialisations { get; set; }
    }
}