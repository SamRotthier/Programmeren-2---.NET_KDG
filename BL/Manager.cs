using MedievalMMO.BL.Domain;
using MedievalMMO.DAL;

namespace MedievalMMO.BL;

public class Manager: IManager
{
    private IRepository _repository;

    public Manager(IRepository repository)
    {
        _repository = repository;
        _repository.Seed();
    }

    public Player GetPlayer(int id)
    {
        return _repository.ReadPlayer(id);
    }

    public List<Player> GetAllPlayers()
    {
        return _repository.ReadAllPlayers();
    }

    public List<Player> GetPlayersByGender(Gender gender)
    {
        return _repository.ReadPlayersByGender(gender);
    }

    public Player AddPlayer(string playerName, DateTime playerBirthdate, Gender playerGender, int playerLevel)
    {
        Player player = new Player(_repository.ReadAllPlayers().Count+1, playerName, playerBirthdate, playerGender, playerLevel);
        _repository.CreatePlayer(player);
        return player;
    }

    public Guild GetGuild(int id)
    {
        return _repository.ReadGuild(id);
    }

    public List<Guild> GetAllGuilds()
    {
        return _repository.ReadAllGuilds();
    }

    public IEnumerable<Guild> GetGuildsByNameAndOrLevel(string guildName = null, int? guildLevel = null)
    {
        return _repository.ReadGuildsByNameAndOrLevel(guildName, guildLevel);
    }

    public Guild AddGuild(string guildName, DateTime guildMadeOn, int guildLevel, string? guildMadeBy = null)
    {
        Guild guild = new Guild(_repository.ReadAllGuilds().Count+1, guildName, guildMadeOn, guildLevel, guildMadeBy);
        _repository.CreateGuild(guild);
        return guild;
    }
}