using Test2.DTOs;

namespace Test2.Services;

public interface IPlayersService
{
    Task<List<ResponsePlayerDTO>> GetPlayerByIdAsync(int playerId);
}