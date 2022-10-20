namespace Raider.ApiClient.Models
{
    public class Member
    {
        public string Name { get; set; }
        public bool Online { get; set; }
        public string Level { get; set; }
        public string Gender { get; set; }
        public string race { get; set; }
        public string Class { get; set; }
        public string? Guild { get; set; }
        public List<Talent>? Talents { get; set; }
        //public List<Profession>? Professions { get; set; }
    }
}