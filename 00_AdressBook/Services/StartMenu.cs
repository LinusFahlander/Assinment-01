using _00_AdressBook.Models;
using Newtonsoft.Json;

namespace _00_AdressBook.Services;

internal class StartMenu
{
    private List<Contact> contacts = new List<Contact>();
    private FileService file = new FileService();

    public string FilePath { get; set; } = null!;

    public void MainMenu()
    {
        try 
        { 
            contacts = JsonConvert.DeserializeObject<List<Contact>>(file.Read(FilePath))!; 
        }
        catch { }

        Console.Clear();
        Console.WriteLine("Välkommen till Adressboken");
        Console.WriteLine("1. Skapa en kontakt");
        Console.WriteLine("2. Visa alla kontakter");
        Console.WriteLine("3. Visa en specifik kontakt");
        Console.WriteLine("4. Ta bort en specifik kontakt\n");
        Console.Write("Välj ett av alternativen ovan: ");
        var option = Console.ReadLine();

        switch (option) 
        {
            case "1": RunOptionOne(); break;
            case "2": RunOptionTwo(); break;
            case "3": RunOptionThree(); break;
            case "4": RunOptionFour(); break;
        }
    }

    private void RunOptionOne()
    {
        Console.Clear();
        Console.WriteLine("Skapa en kontakt:");

        Contact contact = new Contact();
        Console.Write("Ange Förnamn: ");
        contact.FirstName = Console.ReadLine() ?? "";
        Console.Write("Ange Efternamn: ");
        contact.LastName = Console.ReadLine() ?? "";
        Console.Write("Ange Email: ");
        contact.Email = Console.ReadLine() ?? "";
        Console.Write("Ange Telefonnummer: ");
        contact.PhoneNumber = Console.ReadLine() ?? "";
        Console.Write("Ange Gatuadress: ");
        contact.Adress = Console.ReadLine() ?? "";
        Console.Write("Ange Postnummer: ");
        contact.PostalCode = Console.ReadLine() ?? "";
        Console.Write("Ange Ort: ");
        contact.City = Console.ReadLine() ?? "";

        contacts.Add(contact);
        file.Save(FilePath, JsonConvert.SerializeObject(contacts));
    }

    private void RunOptionTwo()
    {
        Console.Clear();
        Console.WriteLine("Kontakter:");
        contacts!.ForEach(contact => Console.WriteLine("Namn: " + contact.FirstName + " " + contact.LastName + " " + "Email: " + contact.Email));

        Console.WriteLine("Tryck valfri tangent för att återgå till Adressboken...");
        Console.ReadKey();
    }
    private void RunOptionThree()
    {
        Console.Clear();
        Console.WriteLine("Visa en specifik kontakt: \n");
        Console.Write("")

    }
    private void RunOptionFour()
    {
        Console.Clear();
        Console.WriteLine("Ta bort en kontakt: ");
    }
}
