using discgolf_app_dataaccess.Mappers;
using discgolf_app_dataaccess.Models;
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
        private readonly Client _supabaseClient;

        public RoundResultController(ILogger<RoundResultController> logger, ICsvMapper csvMapper, Client supabaseClient)
        {
            _logger = logger;
            _csvMapper = csvMapper;
            _supabaseClient = supabaseClient;
        }
        
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Post(IFormFile file)
        {
            if (file == null || file.Length == 0 || !Path.GetExtension(file.FileName).Equals(".csv", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("File is not a csv file");
            }

            var x = await _supabaseClient.From<Player>().Get();
            var models = x.Models[0];

            //var round = await _csvMapper.CsvToModelMapper(file);

            return Created("", models);
        }
    }
}