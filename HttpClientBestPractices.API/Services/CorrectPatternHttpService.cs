using HttpClientBestPractices.API.Services.DTOs;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientBestPractices.API.Services
{
    public sealed class CorrectPatternHttpService : ICorrectPatternHttpService
    {
        private readonly HttpClient _httpClient;

        public CorrectPatternHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<SpaceflightNewDTO>> GetUsingCorrectPatternAsync()
        {           
            var response = await _httpClient.GetAsync("https://api.spaceflightnewsapi.net/v3/articles");
            using var stream = await response.Content.ReadAsStreamAsync();
            using var streamReader = new StreamReader(stream);
            var json = await streamReader.ReadToEndAsync();
            return JsonConvert.DeserializeObject<IEnumerable<SpaceflightNewDTO>>(json);
        }
    }
}
