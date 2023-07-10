using discgolf_app_dataaccess.DbContext;
using discgolf_app_dataaccess.Mappers;
using discgolf_app_dataaccess.Models;
using discgolf_app_dataaccess.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Supabase;

namespace discgolf_app_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoundResultController : ControllerBase
    {

        private readonly ILogger<RoundResultController> _logger;
        private readonly ICsvMapper _csvMapper;
        private readonly IDatabaseConnection _dbClient;

        public RoundResultController(ILogger<RoundResultController> logger, ICsvMapper csvMapper, IDatabaseConnection dbClient)
        {
            _logger = logger;
            _csvMapper = csvMapper;
            _dbClient = dbClient;
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
            var x = new PlayerDto
            {
                Name = round.CourseInfo.CourseName
            };
            
            var result = await _dbClient.PostRound(x);
            return Ok(result);
        }
    }
}