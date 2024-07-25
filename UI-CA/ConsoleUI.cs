using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using MedievalMMO.BL;
using MedievalMMO.Domain;


namespace MedievalMMO.UI.CA;

public class ConsoleUI
{
    private IManager _manager;
    
    // ConsoleUI constructor
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
                DisplayAllPlayers();
                break;
            case 2:
                DisplayPlayerWithGender();
                break;
            case 3:
                DisplayAllGuilds();
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
            default:
                Console.WriteLine("Something went wrong, try again\n"); 
                break;
        }
        Run();
    }



    // displays the menue for the application
    private int? WriteMenueAndReadInput()
    {
        Console.WriteLine("What Would you like to do?"); 
        Console.WriteLine("==========================");
        Console.WriteLine("0) Quit"); 
        Console.WriteLine("1) Show all players"); 
        Console.WriteLine("2) Show players with gender"); //1 condition - search on gender
        Console.WriteLine("3) Show all guilds"); 
        Console.WriteLine("4) Show guilds with name and/or level"); //2 conditions - search on name and/or level
        Console.WriteLine("5) Add a Player to List");
        Console.WriteLine("6) Add a Guild to List");
        Console.WriteLine("Choice (0-6):");
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
    
    // Displays all the players
    private void DisplayAllPlayers()
    {
        List<Player> players= _manager.GetAllPlayers();
        Console.WriteLine("Here are all the players:");
        foreach (var player in players)
        {
            Console.WriteLine(player.ToString());
        }
        Console.WriteLine(""); 
    }
    
    // Displays the different genders
    private static void WriteGenders()
    {
        Console.Write("What gender does the player have? ");
        Gender[] genders = Enum.GetValues<Gender>();
        foreach (var gender in genders)
        {
            Console.Write((int)gender +")"+ gender + " "); //Writes the number of the gender in the enum and then the name of the gender
        }
    }
    
    // Displays the players filtered by chosen gender
    private void DisplayPlayerWithGender()
    {
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
        }
        
        Gender gender = (Gender)inputGender; //casting the number to the enum
        List<Player> players = _manager.GetPlayersByGender(gender);
        
        if (players != null){
            Console.WriteLine("Here are all the players with this gender:");
            foreach (var player in players)
            {
                Console.WriteLine(player.ToString());
            }
            Console.WriteLine("");  
        }
    }
    
    // Displays all the guilds
    private void DisplayAllGuilds()
    {
        List<Guild> guilds = _manager.GetAllGuilds();
        Console.WriteLine("Here are all the guilds:");
        foreach (var guild in guilds)
        {
            Console.WriteLine(guild.ToString());   
        }
        Console.WriteLine("");    
    }
    
    // Displays all the guild that fall into the search criteria
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
                Console.WriteLine(guild.ToString());
            }
            Console.WriteLine("");    
        }
        catch (Exception e)
        {
            Console.WriteLine("Not a valid input\n");
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
        
        Console.WriteLine("Gender( 1)Male, 2)Female, 3)NonBinary, 4)Other) - number only:");
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
        
        
        Console.WriteLine("Level:");
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
            Console.WriteLine(validationException.Message);
            DisplayAddPlayer();
        }
        catch (Exception e)
        {
            Console.WriteLine("There has been an unexpected problem!");
        }
    }
    
    private void DisplayAddGuild()
    {
        Console.WriteLine("Add Guild"); 
        Console.WriteLine("==========================");
        Console.WriteLine("Name:");
        string name = Console.ReadLine();
        
        Console.WriteLine("Level:");
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
        
        Console.WriteLine("Guild Leader:");
        string nameLeader =Console.ReadLine();
        
        try
        {
            _manager.AddGuild(name,DateTime.Now,level, nameLeader);
        }
        catch (ValidationException validationException)
        {
            Console.WriteLine(validationException.Message);
            Console.WriteLine(DateTime.Now.AddHours(10));
            DisplayAddGuild();
        }
        catch (Exception e)
        {
            Console.WriteLine("There has been an unexpected problem!");
        }
    }
}