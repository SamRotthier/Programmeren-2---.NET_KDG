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

    public static string GetGuildWithPlayerInfo(Guild guild)
    {
        string guildInfoText =  $"Guild '{guild.GuildName}' has a level of '{guild.GuildLevel}' and has the following players:";

        if (guild.PlayersInGuild != null)
        {
            foreach (var playersGuild in guild.PlayersInGuild)
            {
                guildInfoText += $"\n\t player name is '{playersGuild.Player.PlayerName}' and has a level of '{playersGuild.Player.PlayerLevel}'";
            }
        }
        else
        {
            guildInfoText += $"\n\t No players Found";
        }
        return guildInfoText;
    }
}
