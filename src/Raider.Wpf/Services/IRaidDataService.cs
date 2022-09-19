using Raider.Domain.Entities;

namespace Raider.Wpf.Services
{
    public interface IRaidDataService : IDataService<Raid>
    {
        Raid Get(string Id);
    }
}