using System.Collections.Generic;

namespace Raider.Wpf.Models
{
    public class Group
    {
        public int Index { get; set; }
        public IEnumerable<Member> Members { get; set; }
    }
}