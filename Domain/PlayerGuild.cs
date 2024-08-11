using System.ComponentModel.DataAnnotations;

namespace MedievalMMO.BL.Domain;

public class PlayerGuild
{
    public int PlayerId { get; set; }
    [Required]
    public Player Player {get; set; }
    public int GuildId { get; set; }
    [Required]
    public Guild Guild { get; set; }
    [Required]
    public DateTime PlayerJoinedGuildOn { get; set; }

    public PlayerGuild(Player player, Guild guild, DateTime playerJoinedGuildOn)
    {
        Player = player;
        Guild = guild;
        PlayerJoinedGuildOn = playerJoinedGuildOn;
    }
    
    public PlayerGuild(Player player, Guild guild)
    {
        Player = player;
        Guild = guild;
        PlayerJoinedGuildOn = DateTime.Now;
    }

    public PlayerGuild()
    {
    }
}