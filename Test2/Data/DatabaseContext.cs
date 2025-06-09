using Microsoft.EntityFrameworkCore;
using Test2.Models;

namespace Test2.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<Map> Maps { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<PlayerMatch> PlayerMatches { get; set; }
    
    
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tournament>(entity =>
        {
            entity.ToTable("Tournament");
            entity.HasKey(e => e.TournamentId);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.StartDate).IsRequired();
            entity.Property(e => e.EndDate).IsRequired();
            entity.HasMany(e => e.Matches).WithOne(e => e.Tournament).HasForeignKey(e => e.TournamentId);
        });

        modelBuilder.Entity<Map>(entity =>
        {
            entity.ToTable("Map");
            entity.HasKey(e => e.MapId);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Type).IsRequired();
            entity.HasMany(e => e.Matches).WithOne(e => e.Map).HasForeignKey(e => e.MapId);
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.ToTable("Player");
            entity.HasKey(e => e.PlayerId);
            entity.Property(e => e.FirstName).IsRequired();
            entity.Property(e => e.LastName).IsRequired();
            entity.Property(e => e.BirthDate).IsRequired();
            entity.HasMany(e => e.PlayerMatches).WithOne(e => e.Player).HasForeignKey(e => e.PlayerId);
        });

        modelBuilder.Entity<Match>(entity =>
        {
            entity.ToTable("Match");
            entity.HasKey(e => e.MatchId);
            entity.Property(e => e.MatchDate).IsRequired();
            entity.Property(e => e.Team1Score).IsRequired();
            entity.Property(e => e.Team2Score).IsRequired();
            entity.Property(e => e.BestRating);
            entity.HasOne(e => e.Map).WithMany(m => m.Matches).HasForeignKey(e => e.MapId);
            entity.HasOne(e => e.Tournament).WithMany(m => m.Matches).HasForeignKey(e => e.TournamentId);
            entity.HasMany(e => e.PlayerMatches).WithOne(e => e.Match).HasForeignKey(e => e.MatchId);
        });

        modelBuilder.Entity<PlayerMatch>(entity =>
        {
            entity.ToTable("Player_Match");
            entity.HasKey(e => new { e.PlayerId, e.MatchId });
            entity.Property(e => e.MVPs).IsRequired();
            entity.HasOne(e => e.Player).WithMany(e => e.PlayerMatches).HasForeignKey(e => e.PlayerId);
            entity.HasOne(e => e.Match).WithMany(e => e.PlayerMatches).HasForeignKey(e => e.MatchId);
        });

        modelBuilder.Entity<Player>().HasData(
            new Player { PlayerId = 1, FirstName = "Alex", LastName = "Smith", BirthDate = new DateTime(2005, 7, 2)},
            new Player { PlayerId = 2, FirstName = "John", LastName = "Doe", BirthDate = new DateTime(1999, 5, 3)}
        );

        modelBuilder.Entity<Tournament>().HasData(
            new Tournament
            {
                TournamentId = 1, Name = "CS2 Summer Cup", StartDate = new DateTime(2010, 1, 1),
                EndDate = new DateTime(2010, 1, 2)
            },
            new Tournament
            {
                TournamentId = 2, Name = "T2", StartDate = new DateTime(2010, 1, 1),
                EndDate = new DateTime(2010, 1, 2)
            });

        modelBuilder.Entity<Map>().HasData(
            new Map { MapId = 1, Name = "Mirage", Type = "grass" });

        modelBuilder.Entity<Match>().HasData(
            new Match
            {
                MatchId = 1, TournamentId = 1, MapId = 1, MatchDate = new DateTime(2010, 1, 1),
                Team1Score = 1, Team2Score = 2, BestRating = 3
            });

        modelBuilder.Entity<PlayerMatch>().HasData(
            new PlayerMatch
            {
                MatchId = 1,
                PlayerId = 1,
                MVPs = 3,
                Rating = 2
            });
    }
}