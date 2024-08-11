using MedievalMMO.BL.Domain;

namespace MedievalMMO.DAL;

public interface IRepository
{
    //void Seed();
    Player ReadPlayer(int id);
    IEnumerable<Player> ReadAllPlayers();
    IEnumerable<Player> ReadAllPlayersWithMonsters();
    Player ReadPlayerWithGuilds(int id);
    IEnumerable<Player> ReadPlayersByGender(Gender gender);
    void CreatePlayer(Player player);
    
    Guild ReadGuild(int id);
    IEnumerable<Guild> ReadAllGuilds();
    IEnumerable<Guild> ReadAllGuildsWithPlayers();
    IEnumerable<Guild> ReadGuildsByNameAndOrLevel(string guildName = null, int? guildLevel = null);
    void CreateGuild(Guild guild);
    IEnumerable<PlayerGuild> ReadAllPlayerGuildsByPlayerId(int playerId);
    void CreatePlayerGuild(PlayerGuild playerGuild);
    void DeletePlayerGuild(int playerId, int guildId);
}