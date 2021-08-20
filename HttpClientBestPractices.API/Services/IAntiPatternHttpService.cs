using HttpClientBestPractices.API.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HttpClientBestPractices.API.Services
{
    public interface IAntiPatternHttpService
    {
        Task<IEnumerable<SpaceflightNewDTO>> GetUsingAntiPattern1();

        Task<IEnumerable<SpaceflightNewDTO>> GetUsingAntiPattern2();
    }
}
