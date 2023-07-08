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
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Post(IFormFile file)
        {

            if (file == null || file.Length == 0 || !Path.GetExtension(file.FileName).Equals(".csv", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("File is not a csv file");
            }
            
            var round = await _csvMapper.CsvToModelMapper(file);

            return Created("", round);
        }
    }
}