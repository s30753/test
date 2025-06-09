using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Test2.Services;

namespace Test2.Controllers;

[Route("api/players")]
[ApiController]
public class PlayersController : ControllerBase
{
    private readonly IPlayersService _playersService;

    public PlayersController(IPlayersService playersService)
    {
        _playersService = playersService;
    }
    
    [HttpGet("{id}/matches")]
    public async Task<IActionResult> GetMatchesForPlayerAsync(int id)
    {
        var playerData = await _playersService.GetPlayerByIdAsync(id);
        if (playerData.IsNullOrEmpty()) return NotFound($"Player with {id} not found");
        return Ok(playerData);
    }
}