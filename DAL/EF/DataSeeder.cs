using MedievalMMO.BL.Domain;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace MedievalMMO.DAL.EF;

public class DataSeeder
{

    public static void Seed(MedievalDbContext context)
    {
        
     // Filling in players
        Player player1 = new Player( "Sam", new DateTime(1998, 04,11), Gender.Male, 11);
        Player player2 = new Player("Pascal",new DateTime(1970, 08,25), Gender.Male, 25);
        Player player3 = new Player("Elyse",new DateTime(2001, 07,16), Gender.Female, 35);
        Player player4 = new Player("Yoda",new DateTime(2016, 04,11), Gender.NonBinary, 99);
        
        // Filling in guilds
        Guild guild1 = new Guild("killers",new DateTime(2023, 10,1), 1, "Sam");
        Guild guild2 = new Guild("skillers",new DateTime(2023, 01,10), 5, "Yoda");
        Guild guild3 = new Guild("smitters",new DateTime(2022, 02,11), 99, "Yoda");
        Guild guild4 = new Guild("gamers",new DateTime(2023, 10,1), 3);
        
        //Filling in monsters
        Monster monster1 = new Monster("Pikachu", Gender.Male, 10, 50.5, false, player1);
        Monster monster2 = new Monster("Gravler", Gender.Female, 15, 100.5, false, player2);
        Monster monster3 = new Monster("Raichu", Gender.Other, 20, 100.5, false, player2);
        Monster monster4 = new Monster( "Charmender", Gender.Other, 30, 100.5, false,null);
        Monster monster5 = new Monster("Charizard", Gender.Other, 25, 100.5, false, player4);
        
        
        // Filling guilds in player
        player1.PlayerGuilds?.Add(guild1);
        player1.PlayerGuilds?.Add(guild2);
        player1.PlayerGuilds?.Add(guild3);
        
        player2.PlayerGuilds?.Add(guild1);
        
        player3.PlayerGuilds?.Add(guild4);
        
        player4.PlayerGuilds?.Add(guild1);
        player4.PlayerGuilds?.Add(guild2);
        player4.PlayerGuilds?.Add(guild3);
        player4.PlayerGuilds?.Add(guild4);
        
        // Filling players in guild
        guild1.PlayersInGuild?.Add(player1);
        guild1.PlayersInGuild?.Add(player2);
        guild1.PlayersInGuild?.Add(player4);
        
        guild2.PlayersInGuild?.Add(player1);
        guild2.PlayersInGuild?.Add(player4);
        
        guild3.PlayersInGuild?.Add(player1);
        guild3.PlayersInGuild?.Add(player4);
        
        guild4.PlayersInGuild?.Add(player3);
        guild4.PlayersInGuild?.Add(player4);
        
        player1.PlayerMonsters?.Add(monster1);
        player2.PlayerMonsters?.Add(monster2);
        player2.PlayerMonsters?.Add(monster3);
        player4.PlayerMonsters?.Add(monster5);
        
        
        
        context.Players.Add(player1);
        context.Players.Add(player2);
        context.Players.Add(player3);
        context.Players.Add(player4);
        context.Guilds.Add(guild1);
        context.Guilds.Add(guild2);
        context.Guilds.Add(guild3);
        context.Guilds.Add(guild4);
        context.Monsters.Add(monster1);
        context.Monsters.Add(monster2);
        context.Monsters.Add(monster3);
        context.Monsters.Add(monster4);
        context.Monsters.Add(monster5);
        
        context.SaveChanges();
        context.ChangeTracker.Clear();
    }
}