using MedievalMMO.BL.Domain;

namespace MedievalMMO.UI.CA.Extensions;

public class GuildExtensions
{
    public static string GetGuildInfo(Guild guild)
    {
        return $"Guild: " +
               $"id:'{guild.GuildId}', " +
               $"Name:'{guild.GuildName}', " +
               $"Made On:'{guild.GuildMadeOn}', " +
               $"Level:'{guild.GuildLevel}', " +
               $"made by:'{guild.GuildMadeBy}'";
        //+ $"players in the guild:'{PlayersInGuild}'";
    }
}