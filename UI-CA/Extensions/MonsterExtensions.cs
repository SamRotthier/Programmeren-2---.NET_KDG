using MedievalMMO.BL.Domain;

namespace MedievalMMO.UI.CA.Extensions;

public class MonsterExtensions
{
    public static string GetMonsterInfo(Monster monster)
    {
        return $"Monster: " +
               $"id:'{monster.MonsterId}', " +
               $"Name:'{monster.MonsterName}', " +
               $"Gender:'{monster.MonsterGender}', " +
               $"Level:'{monster.MonsterLevel}', " +
               $"Health:'{monster.MonsterHealth}', " +
               $"Can Evolve:'{monster.MonsterCanEvolve}'";
    }
}