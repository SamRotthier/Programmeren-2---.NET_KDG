using MedievalMMO.BL.Domain;

namespace MedievalMMO.DAL;

public interface IRepository
{
    //void Seed();
    Player ReadPlayer(int id);
    IEnumerable<Player> ReadAllPlayers();
    IEnumerable<Player> ReadPlayersByGender(Gender gender);
    void CreatePlayer(Player player);
    
    Guild ReadGuild(int id);
    IEnumerable<Guild> ReadAllGuilds();
    IEnumerable<Guild> ReadGuildsByNameAndOrLevel(string guildName = null, int? guildLevel = null);
    void CreateGuild(Guild guild);

}