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

    public bool CreateDatabase(bool dropDatabase)
    {
        if (dropDatabase)
        {
            Database.EnsureDeleted();
        }

        return Database.EnsureCreated();
    }
    
}