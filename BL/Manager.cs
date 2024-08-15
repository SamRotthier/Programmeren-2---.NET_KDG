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
        Player player = new Player(playerName, playerBirthdate, playerGender, playerLevel); //_repository.ReadAllPlayers().ToList().Count+1,
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
/*
    public IEnumerable<Player> GetGuildWithPlayersNotInGuild(int id)
    {
        return _repository.ReadGuildWithPlayersNotInGuild(id);
    }
    */

    public Guild GetGuildWithPlayers(int id)
    {
        return _repository.ReadGuildWithPlayers(id);
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
        Guild guild = new Guild( guildName, guildMadeOn, guildLevel, guildMadeBy);//_repository.ReadAllGuilds().ToList().Count+1,
        this.Validate(guild);
        _repository.CreateGuild(guild);
        return guild;
    }

    public void AddPlayerGuild(int playerId, int guildId)
    {
       Player player = _repository.ReadPlayer(playerId);
       Guild guild = _repository.ReadGuild(guildId);
       PlayerGuild playerGuild = new PlayerGuild(player, guild, DateTime.Now); 
        _repository.CreatePlayerGuild(playerGuild);
    }
    
    public Monster GetMonster(int id)
    {
        return _repository.ReadMonster(id);
    }

    public IEnumerable<Monster> GetAllMonsters()
    {
        return _repository.ReadAllMonsters();
    }

    public Monster AddMonster(string monsterName, Gender monsterGender, int monsterLevel, double monsterHealth,
        bool monsterCanEvolve)
    {
        Monster monster = new Monster(monsterName, monsterGender, monsterLevel, monsterHealth,monsterCanEvolve ); //.ToList is so we can use IEnumerable and still know the index of the new player
        this.Validate(monster);
        _repository.CreateMonster(monster);
        return monster;
    }

    public PlayerGuild GetPlayerGuild(int playerId, int guildId)
    {
        return _repository.ReadPlayerGuild(playerId, guildId);
    }

    public PlayerGuild AddPlayerGuild(int playerId, int guildId, DateTime playerJoinedGuildOn)
    {
        Player player = GetPlayer(playerId);
        Guild guild = GetGuild(guildId);
        PlayerGuild playerGuild = new PlayerGuild(player, guild, playerJoinedGuildOn);
        _repository.CreatePlayerGuild(playerGuild);
        return playerGuild;
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
    
    private void Validate(Monster monster)
    {
        List<ValidationResult> errors = new List<ValidationResult>();
        bool valid = Validator.TryValidateObject(monster, new ValidationContext(monster), errors,true);
        if (!valid)
        {
            throw new ValidationException( string.Join("|", errors));
        }
    }
}