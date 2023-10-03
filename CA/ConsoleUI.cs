namespace Sprint1;

public class ConsoleUI
{
    private readonly List<Player> _players = new List<Player>();
    private readonly List<Guild> _guilds = new List<Guild>();
    
    // ConsoleUI constructor
    public ConsoleUI()
    {
        Seed();
    }

    private void Seed()
    {
        // Filling in players
        Player player1 = new Player(1, "Sam", new DateTime(1998, 04,11), Gender.Male, 11);
        _players.Add(player1);
        Player player2 = new Player(2,"Pascal",new DateTime(1970, 08,25), Gender.Male, 25);
        _players.Add(player2);
        Player player3 = new Player(3,"Elyse",new DateTime(2001, 07,16), Gender.Female, 35);
        _players.Add(player3);
        Player player4 = new Player(4,"Yoda",new DateTime(2016, 04,11), Gender.NonBinary, 99);
        _players.Add(player4);
        
        // Filling in guilds
        Guild guild1 = new Guild(1,"killers",new DateTime(2023, 10,1), 1, "Sam");
        _guilds.Add(guild1);
        Guild guild2 = new Guild(2,"skillers",new DateTime(2023, 01,10), 5, "Yoda");
        _guilds.Add(guild2);
        Guild guild3 = new Guild(3,"smitters",new DateTime(2022, 02,11), 99, "Yoda");
        _guilds.Add(guild3);
        Guild guild4 = new Guild(4,"gamers",new DateTime(2023, 10,1), 3);
        _guilds.Add(guild4);
        
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
        Console.WriteLine("Here are all the players:");
        foreach (var player in _players)
        {
            Console.WriteLine(player.ToString());
        }
        Console.WriteLine(""); 
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
        
        if (inputGender != null){
            Gender gender = (Gender)inputGender; //casting the number back to the enum
            Console.WriteLine("Here are all the players with this gender:");

            foreach (var player in _players)
            {
                if (player.PlayerGender == gender)
                {
                    Console.WriteLine(player.ToString());
                }
                Console.WriteLine("");    
            }
        }
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
    
    // Displays all the guilds
    private void DisplayAllGuilds()
    {
        Console.WriteLine("Here are all the guilds:");
        foreach (var guild in _guilds)
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
            IEnumerable<Guild> filteredGuildList = GuildsFilteredOnNameAndOrLevel(_guilds, guildName, guildLevel);
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