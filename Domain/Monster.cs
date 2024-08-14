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
    [Required(ErrorMessage="Monster Gender cannot be empty")]
    public Gender MonsterGender { get; set; }
    [Required(ErrorMessage="Monster Level cannot be empty")]
    [Range(1,99, ErrorMessage="level should be in range 1-99")]
    public int MonsterLevel { get; set; }
    [Required(ErrorMessage="Monster Health cannot be empty")]
    public double MonsterHealth { get; set; }
    public bool? MonsterCanEvolve { get; set; }
    public Player? OwnedByPlayer { get; set; }
    
    
    
    // constructor
    public Monster(string monsterName, Gender monsterGender, int monsterLevel, double monsterHealth, bool monsterCanEvolve, Player ownedByPlayer)
    {
        MonsterName = monsterName;
        MonsterGender = monsterGender;
        MonsterLevel = monsterLevel;
        MonsterHealth = monsterHealth;
        MonsterCanEvolve = monsterCanEvolve;
        OwnedByPlayer = ownedByPlayer;
    }
    
    public Monster(string monsterName, Gender monsterGender, int monsterLevel, double monsterHealth, bool monsterCanEvolve)
    {
        MonsterName = monsterName;
        MonsterGender = monsterGender;
        MonsterLevel = monsterLevel;
        MonsterHealth = monsterHealth;
        MonsterCanEvolve = monsterCanEvolve;
    }

    public Monster(string monsterName, Gender monsterGender, int monsterLevel, double monsterHealth)
    {
        MonsterName = monsterName;
        MonsterGender = monsterGender;
        MonsterLevel = monsterLevel;
        MonsterHealth = monsterHealth;
    }
    
}