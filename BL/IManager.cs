using MedievalMMO.BL.Domain;

namespace MedievalMMO.BL;

public interface IManager
{
    Player GetPlayer(int id);
    IEnumerable<Player> GetAllPlayers();
    public IEnumerable<Player> GetAllPlayersWithMonsters();
    IEnumerable<Player> GetPlayersByGender(Gender gender);
    Player AddPlayer(string playerName, DateTime playerBirthdate, Gender playerGender, int playerLevel);
    
    Guild GetGuild(int id);
    IEnumerable<Guild> GetAllGuilds();
    public IEnumerable<Guild> GetAllGuildsWithPlayers();
    IEnumerable<Guild> GetGuildsByNameAndOrLevel(string guildName = null, int? guildLevel = null);
    Guild AddGuild(string guildName, DateTime guildMadeOn, int guildLevel, string? guildMadeBy = null);
    void CreatePlayerGuild(int playerId, int guildId);
    void DeletePlayerGuild(int playerId, int guildId);
    IEnumerable<PlayerGuild> GetAllPlayerGuildsByPlayerId(int playerId);
}