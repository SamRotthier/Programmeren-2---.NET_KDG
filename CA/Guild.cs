namespace Sprint1;

public class Guild
{
    // properties
    public int GuildId { get; set; }
    public string GuildName { get; set; }
    public DateTime GuildMadeOn { get; set; }
    public int GuildLevel { get; set; }
    public string GuildMadeBy { get; set; } //playerId
    public ICollection<PlayerGuild>? PlayersInGuild { get; set; } //playerId
    
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
    
}