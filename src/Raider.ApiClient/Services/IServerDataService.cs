using Raider.ApiClient.Models;

namespace Raider.ApiClient.Services
{
    public interface IServerDataService
    {
        Task<Member?> GetCharacterInfo(string characterName, string realm);
        Task<Guild?> GetGuildInfo(string guildName, string realm);
        Task<List<Member>?> GetGuildRosterInfo(string guildName, string realm);
    }
}