using MedievalMMO.BL.Domain;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace MedievalMMO.DAL.EF;

public class DataSeeder
{

    public static void Seed(MedievalDbContext context)
    {
        
     // Filling in players
        Player playerSam = new Player( "Sam", new DateTime(1998, 04,11), Gender.Male, 11);
        Player playerPascal = new Player("Pascal",new DateTime(1970, 08,25), Gender.Male, 25);
        Player playerElyse = new Player("Elyse",new DateTime(2001, 07,16), Gender.Female, 35);
        Player playerYoda = new Player("Yoda",new DateTime(2016, 04,11), Gender.NonBinary, 99);
        
        // Filling in guilds
        Guild guildKillers = new Guild("killers",new DateTime(2023, 10,1), 1, "Sam");
        Guild guildSkillers = new Guild("skillers",new DateTime(2023, 01,10), 5, "Yoda");
        Guild guildSmitters = new Guild("smitters",new DateTime(2022, 02,11), 99, "Yoda");
        Guild guildGamers = new Guild("gamers",new DateTime(2023, 10,1), 3);
        
        //Filling in monsters
        Monster monsterPikachu = new Monster("Pikachu", Gender.Male, 10, 50.5, false, playerSam);
        Monster monsterGravler = new Monster("Gravler", Gender.Female, 15, 100.5, false, playerPascal);
        Monster monsterRaichu = new Monster("Raichu", Gender.Other, 20, 100.5, false, playerPascal);
        Monster monsterCharmender = new Monster( "Charmender", Gender.Other, 30, 100.5, false,null);
        Monster monsterCharizard = new Monster("Charizard", Gender.Other, 25, 100.5, false, playerYoda);
        
        
        // Filling guilds in player
        playerSam.PlayerGuilds?.Add(guildKillers);
        playerSam.PlayerGuilds?.Add(guildSkillers);
        playerSam.PlayerGuilds?.Add(guildSmitters);
        
        playerPascal.PlayerGuilds?.Add(guildKillers);
        
        playerElyse.PlayerGuilds?.Add(guildGamers);
        
        playerYoda.PlayerGuilds?.Add(guildKillers);
        playerYoda.PlayerGuilds?.Add(guildSkillers);
        playerYoda.PlayerGuilds?.Add(guildSmitters);
        playerYoda.PlayerGuilds?.Add(guildGamers);
        
        // Filling players in guild - Door EF is dit eigenlijk overbodig
        guildKillers.PlayersInGuild?.Add(playerSam);
        guildKillers.PlayersInGuild?.Add(playerPascal);
        guildKillers.PlayersInGuild?.Add(playerYoda);
        
        guildSkillers.PlayersInGuild?.Add(playerSam);
        guildSkillers.PlayersInGuild?.Add(playerYoda);
        
        guildSmitters.PlayersInGuild?.Add(playerSam);
        guildSmitters.PlayersInGuild?.Add(playerYoda);
        
        guildGamers.PlayersInGuild?.Add(playerElyse);
        guildGamers.PlayersInGuild?.Add(playerYoda);
        
        playerSam.PlayerMonsters?.Add(monsterPikachu);
        playerPascal.PlayerMonsters?.Add(monsterGravler);
        playerPascal.PlayerMonsters?.Add(monsterRaichu);
        playerYoda.PlayerMonsters?.Add(monsterCharizard);
        
        
        
        context.Players.Add(playerSam);
        context.Players.Add(playerPascal);
        context.Players.Add(playerElyse);
        context.Players.Add(playerYoda);
        context.Guilds.Add(guildKillers);
        context.Guilds.Add(guildSkillers);
        context.Guilds.Add(guildSmitters);
        context.Guilds.Add(guildGamers);
        context.Monsters.Add(monsterPikachu);
        context.Monsters.Add(monsterGravler);
        context.Monsters.Add(monsterRaichu);
        context.Monsters.Add(monsterCharmender);
        context.Monsters.Add(monsterCharizard);
        
        context.SaveChanges();
        context.ChangeTracker.Clear();
    }
}