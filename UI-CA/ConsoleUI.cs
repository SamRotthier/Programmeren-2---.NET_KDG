using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using MedievalMMO.BL;
using MedievalMMO.BL.Domain;
using MedievalMMO.UI.CA.Extensions;


namespace MedievalMMO.UI.CA;

public class ConsoleUI
{
    private IManager _manager;
    
    public ConsoleUI(IManager manager)
    {
        _manager = manager;
    }
    
    public void Run(){ 
        int? input = WriteMenueAndReadInput();
        switch (input)
        {
            case 0:
                Console.WriteLine("Thank you for using my program, it will close now"); 
                return;
            case 1:
                DisplayAllPlayersWithMonsters();
                //DisplayAllPlayers();
                break;
            case 2:
                DisplayPlayerWithGender();
                break;
            case 3:
                DisplayAllGuildsWithPlayers();
                //DisplayAllGuilds();
                break;
            case 4:
                DisplayGuildsWithNameAndOrLevel();
                break;
            case 5:
                DisplayAddPlayer();
                break;
            case 6:
                DisplayAddGuild();
                break;
            case 7:
                DisplayAddPlayerToGuild();
                break;
            case 8:
                DisplayRemovePlayerFromGuild();
                break;
            default:
                Console.WriteLine("Something went wrong, try again\n"); 
                break;
        }
        Run();
    }
    
    private int? WriteMenueAndReadInput()
    {
        Console.WriteLine("What Would you like to do?"); 
        Console.WriteLine("==========================");
        Console.WriteLine("0) Quit"); 
        Console.WriteLine("1) Show all players"); 
        Console.WriteLine("2) Show players with gender"); 
        Console.WriteLine("3) Show all guilds"); 
        Console.WriteLine("4) Show guilds with name and/or level");
        Console.WriteLine("5) Add a Player to List");
        Console.WriteLine("6) Add a Guild to List");
        Console.WriteLine("7) Add a Player to a Guild");
        Console.WriteLine("8) Remove a Player from a Guild");
        Console.WriteLine("Choice (0-8):");
        try
        {
            int? input = int.Parse(Console.ReadLine()!);
            Console.WriteLine("");
            return input;
        }
        catch (Exception e)
        {
            Console.WriteLine("Not a valid input");
            return null;
        }
    }
    
    private void DisplayAllPlayersWithMonsters()
    {
        IEnumerable<Player> players= _manager.GetAllPlayersWithMonsters();
        Console.WriteLine("Here are all the players with their monsters:");
        foreach (var player in players)
        {
            Console.WriteLine(PlayerExtensions.GetPlayerWithMonsterInfo(player));
        }
        Console.WriteLine(""); 
        
    }
    
    private static void WriteGenders()
    {
        Gender[] genders = Enum.GetValues<Gender>();
        foreach (var gender in genders)
        {
            Console.Write((int)gender +")"+ gender + " "); 
        }
    }
    
    private void DisplayPlayerWithGender()
    {
        Console.Write("What gender does the player have? ");
        WriteGenders();
        
        Console.WriteLine("Enter the number associated with the gender below.");
        int? inputGender = null;
        try
        {       
            inputGender = int.Parse(Console.ReadLine()!); 
        }
        catch (Exception e)
        {
            Console.WriteLine("Not a valid input\n");
            Run();
        }
        
        Gender gender = (Gender)inputGender; //casting the number to the enum
        IEnumerable<Player> players = _manager.GetPlayersByGender(gender);
        
        if (players != null){
            Console.WriteLine("Here are all the players with this gender:");
            foreach (var player in players)
            {
                Console.WriteLine(PlayerExtensions.GetPlayerInfo(player));
            }
            Console.WriteLine("");  
        }
        else
        {
            Console.WriteLine("There were no players with the given Gender or a problem with loading the players");
        }
    }
    
    private void DisplayAllGuildsWithPlayers()
    {
        IEnumerable<Guild> guilds = _manager.GetAllGuildsWithPlayers();
        Console.WriteLine("Here are all the guilds With their players:");
        foreach (var guild in guilds)
        {
            Console.WriteLine(GuildExtensions.GetGuildWithPlayerInfo(guild));   
        }
        Console.WriteLine("");    
    }
    
    private void DisplayGuildsWithNameAndOrLevel()
    {
        try
        {
            Console.WriteLine("Please provide the name of (or a part of) the guilds name (this is optional):");
            string guildName = Console.ReadLine();
            Console.WriteLine("Please provide the level of the guild (this is optional):");
            Int32.TryParse(Console.ReadLine(), out int guildLevel);
            
            IEnumerable<Guild> filteredGuildList = _manager.GetGuildsByNameAndOrLevel(guildName,guildLevel);
            
            Console.WriteLine("Here are all the guilds with the given (partial)name or level:");
            foreach (var guild in filteredGuildList)
            {
                Console.WriteLine(GuildExtensions.GetGuildInfo(guild));
            }
            Console.WriteLine("");    
        }
        catch (Exception e)
        {
            Console.WriteLine("Not a valid input\n");
            Run();
        }
    }
    
    private void DisplayAddPlayer()
    {
        Console.WriteLine("Add Player"); 
        Console.WriteLine("==========================");
        Console.WriteLine("Name:");
        string name = Console.ReadLine();
        
        Console.WriteLine("PlayerBirthdate (YYYY-MM-DD):");
        string lineB = Console.ReadLine();
        DateTime birthdate;
        while (!DateTime.TryParseExact(lineB, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None,
                   out birthdate))
        {
            Console.WriteLine("Invalid date, please retry (format yyyy-MM-dd)");
            lineB = Console.ReadLine();
        }
        
        Console.Write("Gender( ");
        WriteGenders();
        Console.WriteLine(" ) - number only:");
        Gender gender = Gender.Other;
        try
        {
            gender =(Gender)Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.WriteLine("Something went wrong while trying to parse the gender, make sure you enter a valid number");
            DisplayAddPlayer();
        }
        
        Console.WriteLine("Level (range 1-99):");
        int level = 1;
        try
        {
            level = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.WriteLine("Something went wrong while trying to parse the level, make sure you enter a valid number");
            DisplayAddPlayer();
        }

        try
        {
            _manager.AddPlayer(name, birthdate, gender, level);
        }
        catch (ValidationException validationException)
        {
            Console.WriteLine("Player not valid - Error(s): " + String.Join("\n", validationException.Message.Split("|")));
            DisplayAddPlayer();
        }
        catch (Exception e)
        {
            Console.WriteLine("There has been an unexpected problem!");
            Run();
        }
    }
    
    private void DisplayAddGuild()
    {
        Console.WriteLine("Add Guild"); 
        Console.WriteLine("==========================");
        Console.WriteLine("Name:");
        string name = Console.ReadLine();
        
        Console.WriteLine("Level (range 1-99):");
        int level= 1;
        try
        {
            level = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.WriteLine("Something went wrong while trying to parse the level, make sure you enter a valid number");
            DisplayAddGuild();
        }
        
        Console.WriteLine("Guild Leader (Optional):");
        string nameLeader = Console.ReadLine();
        
        try
        {
            _manager.AddGuild(name,DateTime.Now,level, nameLeader);
        }
        catch (ValidationException validationException)
        {
            Console.WriteLine("Guild not valid - Error(s): " + String.Join("\n", validationException.Message.Split("|")));
            DisplayAddGuild();
        }
        catch (Exception e)
        {
            Console.WriteLine("There has been an unexpected problem!");
            Run();
        }
    }
    
    private void DisplayAddPlayerToGuild()
    {
        Console.WriteLine("Which Player would you like to add to a new Guild?");

        int selectedPlayerId = SelectPlayer();
        
        Console.WriteLine("Which Guild would you like to assign to this Player?");
        IEnumerable<Guild> guildsToSelect = _manager.GetAllGuilds();
        foreach (Guild g in guildsToSelect)
        {
            Console.WriteLine($"[{g.GuildId}]: {g.GuildName}");
        }
        
        int selectedGuildId = SelectGuild();
        
        try
        {
            _manager.AddPlayerGuild(selectedPlayerId, selectedGuildId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Run();
        }
    }
    
    private void DisplayRemovePlayerFromGuild()
    {
        Console.WriteLine("Which Player would you like to remove a Guild from?:");

        int selectedPlayerId = SelectPlayer();
        
        Console.WriteLine("Which of the player's Guilds would you like to remove from this Player?");
        IEnumerable<PlayerGuild> guildsToSelect = _manager.GetAllPlayerGuildsByPlayerId(selectedPlayerId);
        foreach (PlayerGuild pg in guildsToSelect)
        {
            Console.WriteLine($"[{pg.GuildId}]: {pg.Guild.GuildName}");
        }
        
        int selectedGuildId = SelectGuild();
        
        _manager.DeletePlayerGuild(selectedPlayerId, selectedGuildId);
    }

    private int SelectPlayer()
    {
        IEnumerable<Player> playersToSelect = _manager.GetAllPlayers();
        foreach (Player p in playersToSelect)
        {
            Console.WriteLine($"[{p.PlayerId}]: {p.PlayerName}");
        }
        Console.WriteLine($"Please enter a Player ID:");
        int selectedPlayerId = 0;
        try
        {
            selectedPlayerId = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.WriteLine("Something went wrong while trying to parse the PlayerID, make sure you enter a valid number from the list");
            Run();
        }

        return selectedPlayerId;
    }

    private int SelectGuild()
    {
        Console.WriteLine($"Please enter a Guild ID:");
        int selectedGuildId = 0;
        try
        {
            selectedGuildId = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.WriteLine("Something went wrong while trying to parse the PlayerID, make sure you enter a valid number from the list");
            Run();
        }
        
        return selectedGuildId;
    }
    
}