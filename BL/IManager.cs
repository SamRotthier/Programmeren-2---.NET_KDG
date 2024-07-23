using MedievalMMO.BL.Domain;

namespace MedievalMMO.BL;

public interface IManager
{
    Player GetPlayer(int id);
    List<Player> GetAllPlayers();
    List<Player> GetPlayersByGender(Gender gender);
    Player AddPlayer(string playerName, DateTime playerBirthdate, Gender playerGender, int playerLevel);
    
    Guild GetGuild(int id);
    List<Guild> GetAllGuilds();
    IEnumerable<Guild> GetGuildsByNameAndOrLevel(string guildName = null, int? guildLevel = null);
    Guild AddGuild(string guildName, DateTime guildMadeOn, int guildLevel, string? guildMadeBy = null);
}