using discgolf_app_dataaccess.Models;
using discgolf_app_dataaccess.Models.Dtos;

namespace discgolf_app_dataaccess.DbContext
{
    public interface IDatabaseConnection
    {
        Task<Round> PostRound(Round round);
    }
}