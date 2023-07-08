using Supabase;

namespace discgolf_app_dataaccess.DbContext
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
