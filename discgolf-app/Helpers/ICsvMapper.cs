namespace discgolf_app.Helpers
{
    public interface ICsvMapper
    {
        public Task<Round> CsvToModelMapper(IFormFile file);
    }
}