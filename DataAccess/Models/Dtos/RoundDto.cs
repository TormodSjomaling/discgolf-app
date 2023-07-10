using Postgrest.Attributes;
using Postgrest.Models;

namespace discgolf_app_dataaccess.Models.Dtos
{
    [Table("round")]
    public class RoundDto : BaseModel
    {
        [Column("course_id")]
        public int CourseId { get; set; }
        
        [Column("datetime")]
        public DateTime DateTime { get; set; }
    }
}
