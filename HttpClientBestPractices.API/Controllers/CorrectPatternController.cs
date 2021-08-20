using HttpClientBestPractices.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HttpClientBestPractices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorrectPatternController : ControllerBase
    {
        private readonly ICorrectPatternHttpService _correctPatternHttpService;

        public CorrectPatternController(ICorrectPatternHttpService correctPatternHttpService)
        {
            _correctPatternHttpService = correctPatternHttpService;
        }

        [HttpGet]
        public async Task<IActionResult> CorrectMethod()
        {
            return Ok(await _correctPatternHttpService.GetUsingCorrectPatternAsync());
        }
    }
}
