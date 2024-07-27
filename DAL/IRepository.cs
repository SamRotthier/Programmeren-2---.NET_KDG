using MedievalMMO.BL.Domain;

namespace MedievalMMO.DAL;

public interface IRepository
{
    void Seed();
    Player ReadPlayer(int id);
    ICollection<Player> ReadAllPlayers();
    ICollection<Player> ReadPlayersByGender(Gender gender);
    void CreatePlayer(Player player);
    
    Guild ReadGuild(int id);
    ICollection<Guild> ReadAllGuilds();
    IEnumerable<Guild> ReadGuildsByNameAndOrLevel(string guildName = null, int? guildLevel = null);
    void CreateGuild(Guild guild);

}