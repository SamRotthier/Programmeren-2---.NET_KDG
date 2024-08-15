using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedievalMMO.BL.Domain;

public class Player
{
    [Key]
    public int PlayerId { get; set; }
    [Required(ErrorMessage="Player name cannot be empty")]
    public string PlayerName { get; set; }
    [Required(ErrorMessage="Player birthday cannot be empty")]
    public DateTime PlayerBirthdate { get; set; }
    public Gender? PlayerGender { get; set; }
    [Range(1,99, ErrorMessage="Player level outside of range")]
    public int? PlayerLevel { get; set; }
    public ICollection<Monster>? PlayerMonsters { get; set; }
    public ICollection<PlayerGuild>? PlayerGuilds { get; set; }
    
    public Player(int playerId, string playerName, DateTime playerBirthdate, Gender playerGender, int playerLevel)
    {
        PlayerId = playerId;
        PlayerName = playerName;
        PlayerBirthdate = playerBirthdate;
        PlayerGender = playerGender;
        PlayerLevel = playerLevel;
    }
    
    public Player( string playerName, DateTime playerBirthdate)
    {
        PlayerName = playerName;
        PlayerBirthdate = playerBirthdate;
    }
    
    public Player( string playerName, DateTime playerBirthdate, Gender playerGender, int playerLevel)
    {
        PlayerName = playerName;
        PlayerBirthdate = playerBirthdate;
        PlayerGender = playerGender;
        PlayerLevel = playerLevel;
    }
}