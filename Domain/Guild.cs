using System.ComponentModel.DataAnnotations;

namespace MedievalMMO.Domain;

public class Guild : IValidatableObject 
{
    // properties
    [Key]
    public int GuildId { get; set; }
    
    [MinLengthAttribute(2, ErrorMessage="Min Name Length is 2")]
    public string GuildName { get; set; }
    public DateTime GuildMadeOn { get; set; }
    
    [Range(1,99, ErrorMessage="level should be in range 1-99")]
    public int GuildLevel { get; set; }
    public string GuildMadeBy { get; set; } //playerId
    public ICollection<Player>? PlayersInGuild { get; set; } //playerId
    
    // constructor
    public Guild(int guildId,string guildName, DateTime guildMadeOn, int guildLevel, string? guildMadeBy = null)
    {
        GuildId = guildId;
        GuildName = guildName;
        GuildMadeOn = guildMadeOn;
        GuildLevel = guildLevel;
        GuildMadeBy = guildMadeBy;
    }


    // to string
    public sealed override string ToString()
    {
        return $"Guild: " +
               $"id:'{GuildId}', " +
               $"Name:'{GuildName}', " +
               $"Made On:'{GuildMadeOn}', " +
               $"Level:'{GuildLevel}', " +
               $"made by:'{GuildMadeBy}'";
        //+ $"players in the guild:'{PlayersInGuild}'";
    }
    
    IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
    {
        List<ValidationResult> errors = new List<ValidationResult>();

        if (this.GuildMadeOn > DateTime.Now.AddHours(10))
        {
            errors.Add(new ValidationResult("Guilds cannot be made in the future", 
                new string[] {"GuildMadeOn"}));
        }
        return errors;
    }
}