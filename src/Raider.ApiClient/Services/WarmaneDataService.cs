using Raider.ApiClient.Models;
using System.Net.Http.Json;

namespace Raider.ApiClient.Services
{
    public class WarmaneDataService : IServerDataService
    {
        private readonly HttpClient _apiClient = new HttpClient();

        public async Task<Member?> GetCharacterInfo(string characterName, string realm)
        {
            var CharacterInfoRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://armory.warmane.com/api/character/{characterName}/{realm}/summary"),
            };

            using (var response = await _apiClient.SendAsync(CharacterInfoRequest))
            {
                if (response.IsSuccessStatusCode)
                {
                    var character = await response.Content.ReadFromJsonAsync<Member>();
                    return character;
                }
            }

            return null;
        }

        public async Task<Guild?> GetGuildInfo(string guildName, string realm)
        {
            var GuildInfoRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://armory.warmane.com/api/guild/{guildName}/{realm}/summary"),
            };

            using (var response = await _apiClient.SendAsync(GuildInfoRequest))
            {
                if (response.IsSuccessStatusCode)
                {
                    var guild = await response.Content.ReadFromJsonAsync<Guild>();
                    return guild;
                }
            }

            return null;
        }

        public async Task<List<Member>?> GetGuildRosterInfo(string guildName, string realm)
        {
            var GuildInfoRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://armory.warmane.com/api/guild/{guildName}/{realm}/summary"),
            };

            using (var response = await _apiClient.SendAsync(GuildInfoRequest))
            {
                if (response.IsSuccessStatusCode)
                {
                    var guild = await response.Content.ReadFromJsonAsync<Guild>();
                    return guild?.Roster;
                }
            }

            return null;
        }
    }
}