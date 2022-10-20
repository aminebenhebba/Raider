namespace Raider.ApiClient.Models
{
    public class Guild
    {
        public string Name { get; set; }
        public string Realm { get; set; }
        public string Membercount { get; set; }
        public string Pvepoints { get; set; }
        public Member Leader { get; set; }
        public List<Member> Roster { get; set; }
    }
}