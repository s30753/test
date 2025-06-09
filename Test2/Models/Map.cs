using System.ComponentModel.DataAnnotations;

namespace Test2.Models;

public class Map
{
    [Key]
    [Required]
    public int MapId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Type { get; set; }
    
    public ICollection<Match> Matches { get; set; }
}