using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedievalMMO.BL.Domain;

public class Guild : IValidatableObject 
{
    // properties
    [Key]
    public int GuildId { get; set; }
    [Required(ErrorMessage="Guild name cannot be empty")]
    [MinLength(2, ErrorMessage="Min Name Length is 2")]
    public string GuildName { get; set; }
    [Required(ErrorMessage="Player start date cannot be empty")]
    public DateTime GuildMadeOn { get; set; }
    [Range(1,99, ErrorMessage="level should be in range 1-99")]
    public int? GuildLevel { get; set; }
    public string? GuildMadeBy { get; set; }
    public ICollection<PlayerGuild>? PlayersInGuild { get; set; }
    
    // constructor
    public Guild(int guildId,string guildName, DateTime guildMadeOn, int guildLevel, string? guildMadeBy = null)
    {
        GuildId = guildId;
        GuildName = guildName;
        GuildMadeOn = guildMadeOn;
        GuildLevel = guildLevel;
        GuildMadeBy = guildMadeBy;
    }
    
    public Guild(string guildName, DateTime guildMadeOn, int guildLevel, string? guildMadeBy = null)
    {
        GuildName = guildName;
        GuildMadeOn = guildMadeOn;
        GuildLevel = guildLevel;
        GuildMadeBy = guildMadeBy;
    }
    
    public Guild(string guildName)
    {
        GuildName = guildName;
        GuildMadeOn = DateTime.Now;
        GuildLevel = 1;
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