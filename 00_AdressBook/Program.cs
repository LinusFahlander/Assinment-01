using _00_AdressBook.Services;

var startMenu = new StartMenu();
startMenu.FilePath = @$"{ Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";

while(true)
{
    Console.Clear();
    startMenu.MainMenu();
}