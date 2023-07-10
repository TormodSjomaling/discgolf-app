using discgolf_app_dataaccess.Models.Dtos;

namespace discgolf_app_dataaccess.DbContext
{
    public interface IDatabaseConnection
    {
        Task<PlayerDto> PostRound(PlayerDto round);
    }
}