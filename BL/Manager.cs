using System.ComponentModel.DataAnnotations;
using MedievalMMO.DAL;
using MedievalMMO.Domain;

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
        this.Validate(player);
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
        this.Validate(guild);
        _repository.CreateGuild(guild);
        return guild;
    }
    
    private void Validate(Player player)
    {
        List<ValidationResult> errors = new List<ValidationResult>();
        bool valid = Validator.TryValidateObject(player, new ValidationContext(player), errors, validateAllProperties: true);
        if (!valid)
        {
            throw new ValidationException("Player not valid!" + errors);
        }
    }
    
    private void Validate(Guild guild)
    {
        List<ValidationResult> errors = new List<ValidationResult>();
        bool valid = Validator.TryValidateObject(guild, new ValidationContext(guild), errors, validateAllProperties: true);
        if (!valid)
        {
            throw new ValidationException("Guild not valid!: " + errors);
        }
    }
}