using Microsoft.EntityFrameworkCore;

namespace Test2.Models;

public class Match
{
    public int MatchId { get; set; }
    
    public int TournamentId { get; set; }
    public Tournament Tournament { get; set; }
    
    public int MapId { get; set; }
    public Map Map { get; set; }
    
    public DateTime MatchDate { get; set; }
    public int Team1Score { get; set; }
    public int Team2Score { get; set; }
    [Precision(4,2)]
    public decimal? BestRating { get; set; }
    
    public ICollection<PlayerMatch> PlayerMatches { get; set; }
}