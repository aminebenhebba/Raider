using Microsoft.EntityFrameworkCore;
using Raider.Domain.Entities;
using Raider.Wpf.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Raider.Wpf.Services
{
    public class RaidSetupMapDataService : DataService<RaidSetupMap>, IRaidSetupMapDataService
    {
        public RaidSetupMapDataService(RaiderDbContext context) : base(context)
        {
        }

        public IEnumerable<RaidSetupMap> Get(Guid Id)
        {
            var result = _context.RaidSetupMaps.Include(raidSetupMap => raidSetupMap.Specialisation)
                                               .ThenInclude(specialisation => specialisation.Class)
                                               // TODO : Include Role Too "IF you need it"
                                               .Where(item => item.RaidSetupId.ToString() == Id.ToString())
                                               .AsEnumerable();
            return result;
        }
    }
}