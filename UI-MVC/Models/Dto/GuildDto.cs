using System.ComponentModel.DataAnnotations;


namespace MedievalMMO.UI.Web.Models.Dto;

public class GuildDto
{
    public int GuildId { get; set; }
    public string GuildName { get; set; }
    public string GuildMadeOn { get; set; }
    public int GuildLevel { get; set; }
    public string GuildMadeBy { get; set; }
    
    public IEnumerable<PlayerGuildDto> PlayersInGuild { get; set; }
}