using discgolf_app_dataaccess.Models;
using Microsoft.AspNetCore.Http;

namespace discgolf_app_dataaccess.Mappers
{
    public interface ICsvMapper
    {
        public Task<Round> CsvToModelMapper(IFormFile file);
    }
}