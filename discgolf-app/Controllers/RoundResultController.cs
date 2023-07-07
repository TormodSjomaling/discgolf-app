using discgolf_app.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace discgolf_app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoundResultController : ControllerBase
    {

        private readonly ILogger<RoundResultController> _logger;
        private readonly ICsvMapper _csvMapper;

        public RoundResultController(ILogger<RoundResultController> logger, ICsvMapper csvMapper)
        {
            _logger = logger;
            _csvMapper = csvMapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(IFormFile file)
        {
            var x = await _csvMapper.CsvToModelMapper(file);

            return Ok(x);
        }
    }
}