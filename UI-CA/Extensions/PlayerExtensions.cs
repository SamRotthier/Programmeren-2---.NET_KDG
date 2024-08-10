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

    public static string GetPlayerWithMonsterInfo(Player player)
    {
        string playerInfoText =  $"Player '{player.PlayerName}' has a level of '{player.PlayerLevel}' and has the following monsters:";

        if (player.PlayerMonsters != null && player.PlayerMonsters.Count > 0)
        {
            foreach (var monster in player.PlayerMonsters)
            {
                playerInfoText += $"\n\t Monster name is '{monster.MonsterName}' and has a level of '{monster.MonsterLevel}' and a max health pool of '{monster.MonsterHealth}'";
            }
        }
        else
        {
            playerInfoText += $"\n\t No Monsters Found";
        }

        return playerInfoText;
    }
}