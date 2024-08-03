using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedievalMMO.BL.Domain;

public class Monster
{
    // properties
    [Key]
    public int MonsterId { get; set; }
    [Required(ErrorMessage="Monster name cannot be empty")]
    public string MonsterName { get; set; }
    public Gender MonsterGender { get; set; }
    [Range(1,99, ErrorMessage="level should be in range 1-99")]
    public int MonsterLevel { get; set; }
    public double MonsterHealth { get; set; }
    public bool MonsterCanEvolve { get; set; }
    [NotMapped]
    public Player? OwnedBy { get; set; } //PlayerId
    
    
    
    // constructor
    public Monster(string monsterName, Gender monsterGender, int monsterLevel, double monsterHealth, bool monsterCanEvolve, Player ownedBy)
    {
        MonsterName = monsterName;
        MonsterGender = monsterGender;
        MonsterLevel = monsterLevel;
        MonsterHealth = monsterHealth;
        MonsterCanEvolve = monsterCanEvolve;
        OwnedBy = ownedBy;
    }
    
    public Monster(string monsterName, Gender monsterGender, int monsterLevel, double monsterHealth, bool monsterCanEvolve)
    {
        MonsterName = monsterName;
        MonsterGender = monsterGender;
        MonsterLevel = monsterLevel;
        MonsterHealth = monsterHealth;
        MonsterCanEvolve = monsterCanEvolve;
    }
}