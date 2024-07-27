using MedievalMMO.BL.Domain;

namespace MedievalMMO.UI.CA.Extensions;

public class PlayerExtensions
{
    public static string GetPlayerInfo(Player player)
    {
        return $"Player: " +
               $"id:'{player.PlayerId}', " +
               $"Name:'{player.PlayerName}', " +
               $"Birthdate:'{player.PlayerBirthdate}', " +
               $"Gender:'{player.PlayerGender}', " +
               $"Level:'{player.PlayerLevel}'";
        //+ $"Monsters:'{PlayerMonsters}', " +
        //$"Guilds:'{PlayerGuilds}'";
    }
}