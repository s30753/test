using Microsoft.EntityFrameworkCore;

namespace Test2.Models;

public class PlayerMatch
{
    public int PlayerId { get; set; }
    public Player Player { get; set; }
    public int MatchId { get; set; }
    public Match Match { get; set; }
    public int MVPs { get; set; }
    [Precision(4,2)]
    public decimal Rating { get; set; }
}