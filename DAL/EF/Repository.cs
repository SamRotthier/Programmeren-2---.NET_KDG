using MedievalMMO.BL.Domain;
using Microsoft.EntityFrameworkCore;

namespace MedievalMMO.DAL.EF;

public class Repository : IRepository
{
    private readonly MedievalDbContext _ctx;
    
    public Repository(MedievalDbContext context)
    {
        _ctx = context;
    }

    public Player ReadPlayer(int id)
    {
        return _ctx.Players.Find(id);
    }

    public IEnumerable<Player> ReadAllPlayers()
    {
        return _ctx.Players;
    }
    
    public IEnumerable<Player> ReadAllPlayersWithMonsters()
    {
        return _ctx.Players
            .Include(p => p.PlayerMonsters)
            .ToList();
    }
    
    public Player ReadPlayerWithGuilds(int id)
    {
        return _ctx.Players
            .Include(p => p.PlayerGuilds)
            .ThenInclude(pg => pg.Guild)
            .SingleOrDefault(p => p.PlayerId == id);
    }

    public IEnumerable<Player> ReadPlayersByGender(Gender gender)
    {
        return _ctx.Players.Where(p => p.PlayerGender == gender);
    }

    public void CreatePlayer(Player player)
    {
        _ctx.Players.Add(player);
        _ctx.SaveChanges();
    }

    public Guild ReadGuild(int id)
    {
        return _ctx.Guilds.Find(id);
    }

    public IEnumerable<Guild> ReadAllGuilds()
    {
        return _ctx.Guilds;
    }
    
    public IEnumerable<Guild> ReadAllGuildsWithPlayers()
    {//Eager loading
        return _ctx.Guilds
            .Include(g => g.PlayersInGuild)
            .ThenInclude(pg => pg.Player)
            .ToList();
    }
    
    public IEnumerable<PlayerGuild> ReadAllPlayerGuildsByPlayerId(int playerId)
    {
        return _ctx.PlayerGuilds.Where(pg => pg.PlayerId == playerId);
    }

    public void CreatePlayerGuild(PlayerGuild playerGuild)
    {
        _ctx.PlayerGuilds.Add(playerGuild);
        try
        {
            _ctx.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine("Something went wrong with saving the PlayerGuild (was it unique?)");
            throw;
        }
    }

    public void DeletePlayerGuild(int playerId, int guildId)
    {
        PlayerGuild playerGuild = _ctx.PlayerGuilds.Find(playerId, guildId);
        if (playerGuild != null)
        {
            _ctx.PlayerGuilds.Remove(playerGuild);
            _ctx.SaveChanges();
        }
    }

    public IEnumerable<Guild> ReadGuildsByNameAndOrLevel(string guildName = null, int? guildLevel = null)
    {
        IQueryable<Guild> filterList = _ctx.Guilds;
        if (!string.IsNullOrEmpty(guildName))
        {
            string upperGuildName = guildName.ToUpper();
            filterList = filterList.Where(f => f.GuildName.ToUpper().Contains(upperGuildName));
        }
        if (guildLevel != null && guildLevel > 0)
        {
            filterList = filterList.Where(f => f.GuildLevel == guildLevel.Value);
        }
        return filterList.AsEnumerable();
    }
    
    public Guild ReadGuildWithPlayers(int id)
    {
        return _ctx.Guilds
            .Include(g => g.PlayersInGuild)
            .ThenInclude(pg => pg.Player)
            .SingleOrDefault(g => g.GuildId == id);
    }

    public void CreateGuild(Guild guild)
    {
        _ctx.Guilds.Add(guild);
        _ctx.SaveChanges();
    }
    
    public Monster ReadMonster(int id)
    {
        return _ctx.Monsters.Find(id);
    }

    public IEnumerable<Monster> ReadAllMonsters()
    {
        return _ctx.Monsters;
    }

    public void CreateMonster(Monster monster)
    {
        _ctx.Monsters.Add(monster);
        _ctx.SaveChanges();
    }

    public PlayerGuild ReadPlayerGuild(int playerId, int guildId)
    {
        return _ctx.PlayerGuilds.Find(playerId,guildId);
    }
}