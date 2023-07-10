using Postgrest.Attributes;
using Postgrest.Models;

namespace discgolf_app_dataaccess.Models.Dtos
{
    [Table("player")]
    public class PlayerDto : BaseModel
    {
        [Column("name")]
        public string Name { get; set; }
    }
}
