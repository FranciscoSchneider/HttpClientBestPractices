using HttpClientBestPractices.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HttpClientBestPractices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AntiPatternController : ControllerBase
    {
        private readonly IAntiPatternHttpService _antiPatternService;

        public AntiPatternController(IAntiPatternHttpService antiPatternService)
        {
            _antiPatternService = antiPatternService;
        }

        [HttpGet("BadMethod1")]
        public async Task<IActionResult> BadMethod1()
        {
            return Ok(await _antiPatternService.GetUsingAntiPattern1());
        }

        [HttpGet("BadMethod2")]
        public async Task<IActionResult> BadMethod2()
        {
            return Ok(await _antiPatternService.GetUsingAntiPattern2());
        }
    }
}
