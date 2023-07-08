using Supabase;

namespace DataAccess.DbContext
{
    public class DatabaseConnection
    {
        private readonly Client _supabaseClient;

        public DatabaseConnection(Client supabaseClient)
        {
            _supabaseClient = supabaseClient;
        }
        
    }
}
