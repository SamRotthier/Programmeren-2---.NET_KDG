// See https://aka.ms/new-console-template for more information


using MedievalMMO.BL;
using MedievalMMO.DAL;
using MedievalMMO.DAL.EF;
using MedievalMMO.UI.CA;
using Microsoft.EntityFrameworkCore;

var DbContextOptionsBuilder = new DbContextOptionsBuilder<MedievalDbContext>();
DbContextOptionsBuilder.UseSqlite("Data Source=../../../../MedievalDb.db");
MedievalDbContext context = new MedievalDbContext(DbContextOptionsBuilder.Options);

IRepository repository = new Repository(context);
IManager manager = new Manager(repository);

if (context.CreateDatabase(dropDatabase: true))
    DataSeeder.Seed(context);

ConsoleUI consoleUi = new ConsoleUI(manager);
consoleUi.Run();
