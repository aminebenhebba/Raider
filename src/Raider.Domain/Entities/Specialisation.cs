namespace Raider.Domain.Entities
{
    public class Specialisation
    {
        public string Id { get; set; }
        public string ClassId { get; set; }
        public string RoleId { get; set; }
        public string? Icon { get; set; }

        public Class Class { get; set; }
        public Role Role { get; set; }
    }
}