using Postgrest.Attributes;
using Postgrest.Models;

namespace discgolf_app_dataaccess.Models.Dtos
{
    [Table("hole")]
    public class HoleDto : BaseModel
    {
        [Column("course_id")]
        public int CourseId { get; set; }
        
        [Column("hole_number")]
        public int HoleNumber { get; set; }
        
        [Column("par")]
        public int Par { get; set; }
    }
}
