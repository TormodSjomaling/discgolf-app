using Postgrest.Attributes;
using Postgrest.Models;

namespace discgolf_app_dataaccess.Models.Dtos
{
    [Table("course")]
    public class CourseDto : BaseModel
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("location")]
        public string Location { get; set; }

        [Column("layout")]
        public string Layout { get; set; }
    }
}
