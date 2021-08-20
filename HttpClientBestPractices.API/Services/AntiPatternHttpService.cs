using HttpClientBestPractices.API.Services.DTOs;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientBestPractices.API.Services
{

    public sealed class AntiPatternHttpService : IAntiPatternHttpService
    {
        public async Task<IEnumerable<SpaceflightNewDTO>> GetUsingAntiPattern1()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://api.spaceflightnewsapi.net/v3/articles");
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<SpaceflightNewDTO>>(json);
        }

        public async Task<IEnumerable<SpaceflightNewDTO>> GetUsingAntiPattern2()
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://api.spaceflightnewsapi.net/v3/articles");
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<SpaceflightNewDTO>>(json);
        }
    }
}
