// See https://aka.ms/new-console-template for more information


using MedievalMMO.BL;
using MedievalMMO.DAL;
using MedievalMMO.UI.CA;


IRepository repository = new InMemoryRepository();
IManager manager = new Manager(repository);

ConsoleUI consoleUi = new ConsoleUI(manager);
consoleUi.Run();
