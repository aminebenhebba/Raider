using Raider.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Raider.Wpf.Services
{
    public interface IRaidSetupMapDataService : IDataService<RaidSetupMap>
    {
        IEnumerable<RaidSetupMap> Get(Guid Id);
    }
}