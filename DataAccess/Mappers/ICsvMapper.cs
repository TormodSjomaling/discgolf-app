using DataAccess.Models;
using Microsoft.AspNetCore.Http;

namespace DataAccess.Mappers
{
    public interface ICsvMapper
    {
        public Task<Round> CsvToModelMapper(IFormFile file);
    }
}