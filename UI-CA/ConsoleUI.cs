using System.Diagnostics;
using MedievalMMO.BL;
using MedievalMMO.BL.Domain;

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
        Console.WriteLine("Choice (0-4):");
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
    
    // Lamda expression for easy filtering
    IEnumerable<Guild> GuildsFilteredOnNameAndOrLevel(List<Guild> listOfGuilds, string guildName = null, int? guildLevel = null )
    {
        IEnumerable<Guild> result = listOfGuilds; // IEnumerable so we can work more easily with the fitlers
        // Filter on name or part of name
        if (!string.IsNullOrEmpty(guildName))
        {
            result = result.Where(f => f.GuildName.Contains(guildName, StringComparison.OrdinalIgnoreCase));
        }
        // Filter on Level
        if (guildLevel != null && guildLevel > 0)
        {
            result = result.Where(f => f.GuildLevel == guildLevel.Value);
        }
        return result;
    }
}