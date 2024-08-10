using System.Diagnostics;
using MedievalMMO.BL.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MedievalMMO.DAL.EF;

public class MedievalDbContext : DbContext
{
    public DbSet<Player> Players { get; set; }
    public DbSet<Guild> Guilds { get; set; }
    public DbSet<Monster> Monsters { get; set; }
    public DbSet<PlayerGuild> PlayerGuild { get; set; }
    
    public MedievalDbContext(DbContextOptions options) : base(options)
    {
        
    }
    


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured){
            optionsBuilder.UseSqlite("Data Source=../../../../MedievalDb.db"); //or .sqlight
        }
            
        optionsBuilder.LogTo(message => Debug.WriteLine(message), LogLevel.Information);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<PlayerGuild>()
            .HasOne(pg => pg.Player)
            .WithMany(p => p.PlayerGuilds)
            .HasForeignKey(pg => pg.PlayerId);

        modelBuilder.Entity<Player>()
            .HasMany(p => p.PlayerGuilds)
            .WithOne(pg => pg.Player)
            .IsRequired(false);
        
        modelBuilder.Entity<PlayerGuild>()
            .HasOne(pg => pg.Guild)
            .WithMany(g => g.PlayersInGuild)
            .HasForeignKey(pg => pg.GuildId);
        
        modelBuilder.Entity<Guild>()
            .HasMany(g => g.PlayersInGuild)
            .WithOne(pg => pg.Guild)
            .IsRequired(false);
        
        modelBuilder.Entity<PlayerGuild>()
            .HasKey(pg => new { pg.PlayerId, pg.GuildId });
        
        modelBuilder.Entity<Monster>()
            .HasOne(m => m.OwnedByPlayer)
            .WithMany(p => p.PlayerMonsters)
            .HasForeignKey("PlayerId")
            .IsRequired(false);
        
        modelBuilder.Entity<Player>()
            .HasMany(p => p.PlayerMonsters)
            .WithOne(m => m.OwnedByPlayer)
            .IsRequired(false);
    }

    public bool CreateDatabase(bool dropDatabase)
    {
        if (dropDatabase)
        {
            Database.EnsureDeleted();
        }

        return Database.EnsureCreated();
    }
    
}