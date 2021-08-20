using HttpClientBestPractices.API.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HttpClientBestPractices.API.Services
{
    public interface ICorrectPatternHttpService
    {
        Task<IEnumerable<SpaceflightNewDTO>> GetUsingCorrectPatternAsync();
    }
}
