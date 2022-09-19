using Raider.Domain.Entities;
using Raider.Wpf.Persistence;
using System.Linq;

namespace Raider.Wpf.Services
{
    public class RaidDataService : DataService<Raid>, IRaidDataService
    {
        public RaidDataService(RaiderDbContext context): base(context)
        {
        }

        public Raid Get(string Id)
        {
            return _context.Raids.First(item => item.Id == Id);
        }
    }
}