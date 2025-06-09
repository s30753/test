using Microsoft.EntityFrameworkCore;
using Test2.Data;
using Test2.DTOs;
using Test2.Models;

namespace Test2.Services;

public class PlayersService : IPlayersService
{
    private readonly DatabaseContext _context;

    public PlayersService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<List<ResponsePlayerDTO>> GetPlayerByIdAsync(int playerId)
    {
        var player = await _context.Players.Where(p => p.PlayerId == playerId)
            .Select(p => new ResponsePlayerDTO
            {
                PlayerId = p.PlayerId,
                FirstName = p.FirstName,
                LastName = p.LastName,
                BirthDate = p.BirthDate,
                Matches = p.PlayerMatches.Select(pm => new ResponseMatchDTO
                {
                    Tournament = pm.Match.Tournament.Name,
                    Map = pm.Match.Map.Name,
                    Date = pm.Match.MatchDate,
                    MVPs = pm.MVPs,
                    Team1Score = pm.Match.Team1Score,
                    Team2Score = pm.Match.Team2Score
                }).ToList()
            }).ToListAsync();
        
        return player;
    }
}