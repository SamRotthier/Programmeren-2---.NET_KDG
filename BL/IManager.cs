using MedievalMMO.BL.Domain;

namespace MedievalMMO.BL;

public interface IManager
{
    Player GetPlayer(int id);
    IEnumerable<Player> GetAllPlayers();
    IEnumerable<Player> GetAllPlayersWithMonsters();
    Player GetPlayerWithGuilds(int id);
    IEnumerable<Player> GetPlayersByGender(Gender gender);
    Player AddPlayer(string playerName, DateTime playerBirthdate, Gender playerGender, int playerLevel);
    Guild GetGuild(int id);
    IEnumerable<Guild> GetAllGuilds();
    IEnumerable<Guild> GetAllGuildsWithPlayers();
    IEnumerable<Guild> GetGuildsByNameAndOrLevel(string guildName = null, int? guildLevel = null);
    Guild AddGuild(string guildName, DateTime guildMadeOn, int guildLevel, string? guildMadeBy = null);
    Guild GetGuildWithPlayers(int id);
    PlayerGuild GetPlayerGuild(int playerId, int guildId);
    void AddPlayerGuild(int playerId, int guildId);
    PlayerGuild AddPlayerGuild(int playerId, int guildId, DateTime playerJoinedGuildOn);
    void DeletePlayerGuild(int playerId, int guildId);
    IEnumerable<PlayerGuild> GetAllPlayerGuildsByPlayerId(int playerId);
    Monster GetMonster(int id);
    IEnumerable<Monster> GetAllMonsters();
    Monster AddMonster(string monsterName, Gender monsterGender, int monsterLevel, double monsterHealth, bool monsterCanEvolve);
}
