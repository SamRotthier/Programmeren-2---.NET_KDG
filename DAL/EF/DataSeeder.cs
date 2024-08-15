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
        
        playerSam.PlayerMonsters?.Add(monsterPikachu);
        playerPascal.PlayerMonsters?.Add(monsterGravler);
        playerPascal.PlayerMonsters?.Add(monsterRaichu);
        playerYoda.PlayerMonsters?.Add(monsterCharizard);

        context.SaveChanges();
        
        PlayerGuild playerGuildSK = new PlayerGuild(playerSam, guildKillers, new DateTime(2020, 11, 02, 14, 00, 00));
        PlayerGuild playerGuildPK = new PlayerGuild(playerPascal, guildKillers, new DateTime(2022, 12, 05, 19, 00, 00));
        PlayerGuild playerGuildSG = new PlayerGuild(playerSam, guildGamers, new DateTime(2023, 04, 08, 14, 00, 00));
        PlayerGuild playerGuildES = new PlayerGuild(playerElyse, guildSmitters, new DateTime(2021, 01, 05, 08, 00, 00));
        PlayerGuild playerGuildYS = new PlayerGuild(playerYoda, guildSmitters, new DateTime(2021, 01, 05, 12, 00, 00));
        
        
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
        context.PlayerGuilds.Add(playerGuildSK);
        context.PlayerGuilds.Add(playerGuildPK);
        context.PlayerGuilds.Add(playerGuildSG);
        context.PlayerGuilds.Add(playerGuildES);
        context.PlayerGuilds.Add(playerGuildYS);
        
        context.SaveChanges();
        context.ChangeTracker.Clear();
    }
}