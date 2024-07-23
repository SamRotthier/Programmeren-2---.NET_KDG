using MedievalMMO.BL.Domain;

namespace MedievalMMO.DAL;

public interface IRepository
{
    void Seed();
    Player ReadPlayer(int id);
    List<Player> ReadAllPlayers();
    List<Player> ReadPlayersByGender(Gender gender);
    void CreatePlayer(Player player);
    
    Guild ReadGuild(int id);
    List<Guild> ReadAllGuilds();
    IEnumerable<Guild> ReadGuildsByNameAndOrLevel(string guildName = null, int? guildLevel = null);
    void CreateGuild(Guild guild);

}