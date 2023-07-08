using Postgrest.Attributes;
using Postgrest.Models;

namespace discgolf_app_dataaccess.Models
{
    [Table("player")]
    public class Player : BaseModel
    {
        [PrimaryKey("player_id")]
        public string PlayerId { get; set; }
        
        [Column("name")]
        public string Name { get; set; }

    }
}
