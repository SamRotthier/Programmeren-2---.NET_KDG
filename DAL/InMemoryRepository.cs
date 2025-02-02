using MedievalMMO.BL.Domain;

namespace MedievalMMO.DAL;

public class InMemoryRepository : IRepository
{
    private static List<Player> _players = new List<Player>();
    private static List<Guild> _guilds = new List<Guild>();
    
    public static void Seed()
    {
        // Filling in players
        Player player1 = new Player(_players.Count+1, "Sam", new DateTime(1998, 04,11), Gender.Male, 11);
        _players.Add(player1);
        Player player2 = new Player(_players.Count+1,"Pascal",new DateTime(1970, 08,25), Gender.Male, 25);
        _players.Add(player2);
        Player player3 = new Player(_players.Count+1,"Elyse",new DateTime(2001, 07,16), Gender.Female, 35);
        _players.Add(player3);
        Player player4 = new Player(_players.Count+1,"Yoda",new DateTime(2016, 04,11), Gender.NonBinary, 99);
        _players.Add(player4);
        
        // Filling in guilds
        Guild guild1 = new Guild(_guilds.Count+1,"killers",new DateTime(2023, 10,1), 1, "Sam");
        _guilds.Add(guild1);
        Guild guild2 = new Guild(_guilds.Count+1,"skillers",new DateTime(2023, 01,10), 5, "Yoda");
        _guilds.Add(guild2);
        Guild guild3 = new Guild(_guilds.Count+1,"smitters",new DateTime(2022, 02,11), 99, "Yoda");
        _guilds.Add(guild3);
        Guild guild4 = new Guild(_guilds.Count+1,"gamers",new DateTime(2023, 10,1), 3);
        _guilds.Add(guild4);
        
        /* Uitgezet voor sprint4 werkende te krijgen
        // Filling guilds in player
        player1.PlayerGuilds?.Add(guild1);
        player1.PlayerGuilds?.Add(guild2);
        player1.PlayerGuilds?.Add(guild3);
        
        player2.PlayerGuilds?.Add(guild1);
        
        player3.PlayerGuilds?.Add(guild4);
        
        player4.PlayerGuilds?.Add(guild1);
        player4.PlayerGuilds?.Add(guild2);
        player4.PlayerGuilds?.Add(guild3);
        player4.PlayerGuilds?.Add(guild4);
        
        // Filling players in guild
        guild1.PlayersInGuild?.Add(player1);
        guild1.PlayersInGuild?.Add(player2);
        guild1.PlayersInGuild?.Add(player4);
        
        guild2.PlayersInGuild?.Add(player1);
        guild2.PlayersInGuild?.Add(player4);
        
        guild3.PlayersInGuild?.Add(player1);
        guild3.PlayersInGuild?.Add(player4);
        
        guild4.PlayersInGuild?.Add(player3);
        guild4.PlayersInGuild?.Add(player4);
        */
    }
    
    public Player ReadPlayer(int id)
    {
        return _players.ElementAt(id);
    }

    public IEnumerable<Player> ReadAllPlayers()
    {
        return _players;
    }

    public IEnumerable<Player> ReadAllPlayersWithMonsters()
    {
        throw new NotImplementedException();
    }

    public Player ReadPlayerWithGuilds(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Player> ReadPlayersByGender(Gender gender)
    {
        return _players.Where(player => player.PlayerGender == gender).ToList();
    }

    public void CreatePlayer(Player player)
    {
        _players.Add(player);
    }

    public Guild ReadGuild(int id)
    {
        return _guilds.ElementAt(id);
    }

    public IEnumerable<Guild> ReadAllGuilds()
    {
        return _guilds;
    }

    public IEnumerable<Guild> ReadAllGuildsWithPlayers()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Guild> ReadGuildsByNameAndOrLevel(string guildName = null, int? guildLevel = null)
    {
        IEnumerable<Guild> filterList = _guilds;
        if (!string.IsNullOrEmpty(guildName))
        {
            filterList = filterList.Where(f => f.GuildName.Contains(guildName, StringComparison.OrdinalIgnoreCase));
        }
        // Filter on Level
        if (guildLevel != null && guildLevel > 0)
        {
            filterList = filterList.Where(f => f.GuildLevel == guildLevel.Value);
        }
        return filterList;
    }

    public void CreateGuild(Guild guild)
    {
        _guilds.Add(guild);
    }

    public IEnumerable<PlayerGuild> ReadAllPlayerGuildsByPlayerId(int playerId)
    {
        throw new NotImplementedException();
    }



    public Guild ReadGuildWithPlayers(int id)
    {
        throw new NotImplementedException();
    }

    public void CreatePlayerGuild(PlayerGuild playerGuild)
    {
        throw new NotImplementedException();
    }

    public void DeletePlayerGuild(int playerId, int guildId)
    {
        throw new NotImplementedException();
    }

    public Monster ReadMonster(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Monster> ReadAllMonsters()
    {
        throw new NotImplementedException();
    }

    public void CreateMonster(Monster monster)
    {
        throw new NotImplementedException();
    }

    public PlayerGuild ReadPlayerGuild(int playerId, int guildId)
    {
        throw new NotImplementedException();
    }
}