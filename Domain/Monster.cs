using System.ComponentModel.DataAnnotations;

namespace MedievalMMO.BL.Domain;

public class Monster
{
    // properties
    [Key]
    public int MonsterId { get; private set; }
    [Required(ErrorMessage="Monster name cannot be empty")]
    public string MonsterName { get; private set; }
    public Gender MonsterGender { get; private set; }
    [Range(1,99, ErrorMessage="level should be in range 1-99")]
    public int MonsterLevel { get; private set; }
    public double MonsterHealth { get; private set; }
    public bool MonsterCanEvolve { get; private set; }
    public int? OwnedBy { get; private set; } //PlayerId
    
    
    
    // constructor
    public Monster(int monsterId,string monsterName, Gender monsterGender, int monsterLevel, double monsterHealth, bool monsterCanEvolve, int? ownedBy)
    {
        MonsterId = monsterId;
        MonsterName = monsterName;
        MonsterGender = monsterGender;
        MonsterLevel = monsterLevel;
        MonsterHealth = monsterHealth;
        MonsterCanEvolve = monsterCanEvolve;
        OwnedBy = ownedBy;
    }

    // to string
    public sealed override string ToString()
    {
        return $"Monster: " +
               $"id:'{MonsterId}', " +
               $"Name:'{MonsterName}', " +
               $"Gender:'{MonsterGender}', " +
               $"Level:'{MonsterLevel}', " +
               $"Health:'{MonsterHealth}', " +
               $"Can Evolve:'{MonsterCanEvolve}'";
    }
    
}