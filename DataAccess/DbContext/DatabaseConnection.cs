using discgolf_app_dataaccess.Models.Dtos;
using Postgrest;
using static Postgrest.QueryOptions;

namespace discgolf_app_dataaccess.DbContext
{
    public class DatabaseConnection : IDatabaseConnection
    {
        private readonly Supabase.Client _supabaseClient;

        public DatabaseConnection(Supabase.Client supabaseClient)
        {
            _supabaseClient = supabaseClient;
        }
        
        public async Task<PlayerDto> PostRound(PlayerDto round)
        {
            var result = await _supabaseClient
            .From<PlayerDto>()
              .Insert(round, new QueryOptions { Returning = ReturnType.Representation });
            
            return null;
        }
    }
}
