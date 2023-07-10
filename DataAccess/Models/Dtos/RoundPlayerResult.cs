using Postgrest.Attributes;
using Postgrest.Models;

namespace discgolf_app_dataaccess.Models.Dtos
{
    [Table("round_player_result")]
    public class RoundPlayerResultDto : BaseModel
    {
        [Column("round_id")]
        public int RoundId { get; set; }
        
        [Column("player_id")]
        public int PlayerId { get; set; }
        
        [Column("hole_id")]
        public int HoleId { get; set; }
        
        [Column("datetime")]
        public DateTime DateTime { get; set; }
    }
}