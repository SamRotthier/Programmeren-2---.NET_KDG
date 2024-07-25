using System.ComponentModel.DataAnnotations;

namespace MedievalMMO.Domain;

public class Player
{
    // properties
    [Key]
    public int PlayerId { get; set; } // to make relations between classes
    
    [Required(ErrorMessage="Player name cannot be empty")]
    public string PlayerName { get; set; }
    
    public DateTime PlayerBirthdate { get; set; }
    public Gender PlayerGender { get; set; }
    
    [Range(1,99, ErrorMessage="Player level outside of range")]
    public int PlayerLevel { get; set; }
    public ICollection<Monster>? PlayerMonsters { get; set; }
    public ICollection<Guild>? PlayerGuilds { get; set; }
    
    // constructor
    public Player(int playerId, string playerName, DateTime playerBirthdate, Gender playerGender, int playerLevel)
    {
        PlayerId = playerId;
        PlayerName = playerName;
        PlayerBirthdate = playerBirthdate;
        PlayerGender = playerGender;
        PlayerLevel = playerLevel;
    }

    // to string
    public sealed override string ToString()
    {
        return $"Player: " +
               $"id:'{PlayerId}', " +
               $"Name:'{PlayerName}', " +
               $"Birthdate:'{PlayerBirthdate}', " +
               $"Gender:'{PlayerGender}', " +
               $"Level:'{PlayerLevel}'";
        //+ $"Monsters:'{PlayerMonsters}', " +
        //$"Guilds:'{PlayerGuilds}'";
    }


}