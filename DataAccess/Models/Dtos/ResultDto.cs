using Postgrest.Attributes;
using Postgrest.Models;

namespace discgolf_app_dataaccess.Models.Dtos
{
    [Table("result")]
    public class ResultDto : BaseModel
    {
        [Column("course_id")]
        public int CourseId { get; set; }
        
        [Column("hole_id")]
        public int HoleId { get; set; }
        
        [Column("player_id")]
        public int PlayerId { get; set; }
        
        [Column("score")]
        public string Score { get; set; }
    }
}
