using System.ComponentModel.DataAnnotations;
using MedievalMMO.BL.Domain;
using MedievalMMO.DAL;

namespace MedievalMMO.BL;

public class Manager: IManager
{
    private IRepository _repository;

    public Manager(IRepository repository)
    {
        _repository = repository;
        InMemoryRepository.Seed();
    }

    public Player GetPlayer(int id)
    {
        return _repository.ReadPlayer(id);
    }

    public IEnumerable<Player> GetAllPlayers()
    {
        return _repository.ReadAllPlayers();
    }

    public IEnumerable<Player> GetAllPlayersWithMonsters()
    {
        return _repository.ReadAllPlayersWithMonsters();
    }

    public Player GetPlayerWithGuilds(int id)
    {
        return _repository.ReadPlayerWithGuilds(id);
    }

    public IEnumerable<Player> GetPlayersByGender(Gender gender)
    {
        return _repository.ReadPlayersByGender(gender);
    }

    public Player AddPlayer(string playerName, DateTime playerBirthdate, Gender playerGender, int playerLevel)
    {
        Player player = new Player(_repository.ReadAllPlayers().ToList().Count+1, playerName, playerBirthdate, playerGender, playerLevel); //.ToList is so we can use IEnumerable and still know the index of the new player
        this.Validate(player);
        _repository.CreatePlayer(player);
        return player;
    }

    public Guild GetGuild(int id)
    {
        return _repository.ReadGuild(id);
    }

    public IEnumerable<Guild> GetAllGuilds()
    {
        return _repository.ReadAllGuilds();
    }

    public IEnumerable<Guild> GetAllGuildsWithPlayers()
    {
        return _repository.ReadAllGuildsWithPlayers();
    }

    public void DeletePlayerGuild(int playerId, int guildId)
    {
        _repository.DeletePlayerGuild(playerId, guildId);
    }

    public IEnumerable<PlayerGuild> GetAllPlayerGuildsByPlayerId(int playerId)
    {
        return _repository.ReadAllPlayerGuildsByPlayerId(playerId);
    }

    public IEnumerable<Guild> GetGuildsByNameAndOrLevel(string guildName = null, int? guildLevel = null)
    {
        return _repository.ReadGuildsByNameAndOrLevel(guildName, guildLevel);
    }

    public Guild AddGuild(string guildName, DateTime guildMadeOn, int guildLevel, string? guildMadeBy = null)
    {
        Guild guild = new Guild(_repository.ReadAllGuilds().ToList().Count+1, guildName, guildMadeOn, guildLevel, guildMadeBy);
        this.Validate(guild);
        _repository.CreateGuild(guild);
        return guild;
    }

    public void CreatePlayerGuild(int playerId, int guildId)
    {
       Player player = _repository.ReadPlayer(playerId);
       Guild guild = _repository.ReadGuild(guildId);
       PlayerGuild playerGuild = new PlayerGuild(player, guild, DateTime.Now); 
        _repository.CreatePlayerGuild(playerGuild);
    }

    private void Validate(Player player)
    {
        List<ValidationResult> errors = new List<ValidationResult>();
        bool valid = Validator.TryValidateObject(player, new ValidationContext(player), errors,true);
        if (!valid)
        {
            throw new ValidationException( string.Join("|", errors));
        }
    }
    
    private void Validate(Guild guild)
    {
        List<ValidationResult> errors = new List<ValidationResult>();
        bool valid = Validator.TryValidateObject(guild, new ValidationContext(guild), errors, true);
        if (!valid)
        {
            throw new ValidationException( string.Join("|", errors));
        }
    }
}