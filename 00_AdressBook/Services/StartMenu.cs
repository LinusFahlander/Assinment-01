using _00_AdressBook.Models;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

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
        string _FirstName = Console.ReadLine()!;
        _FirstName = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(_FirstName!.ToLower());
        contact.FirstName = _FirstName ?? "";

        Console.Write("Ange Efternamn: ");
        string _LastName = Console.ReadLine()!;
        _LastName = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(_LastName!.ToLower());
        contact.LastName = _LastName ?? "";

        Console.Write("Ange Email: ");
        contact.Email = Console.ReadLine() ?? "";

        Console.Write("Ange Telefonnummer: ");
        contact.PhoneNumber = Console.ReadLine() ?? "";

        Console.Write("Ange Gatuadress: ");
        string _Adress = Console.ReadLine()!;
        _Adress = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(_Adress!.ToLower());
        contact.Adress = _Adress ?? "";

        Console.Write("Ange Postnummer: ");
        contact.PostalCode = Console.ReadLine() ?? "";

        Console.Write("Ange Ort: ");
        string _City = Console.ReadLine()!;
        _City = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(_City!.ToLower());
        contact.City = _City ?? "";

        contacts.Add(contact);
        file.Save(FilePath, JsonConvert.SerializeObject(contacts));
    }

    private void RunOptionTwo()
    {
        Console.Clear();
        Console.WriteLine("Kontakter:");
        Console.WriteLine("----------------------------------------------------------------------------------------------------------");
        contacts!.ForEach(contact => Console.WriteLine("Namn: " + contact.FirstName + " " + contact.LastName + " \t " + "Email: " + contact.Email));
        Console.WriteLine("----------------------------------------------------------------------------------------------------------");
        Console.WriteLine("Tryck valfri tangent för att återgå till Adressboken...");
        Console.ReadKey();
    }
    private void RunOptionThree()
    {
        Console.Clear();
        Console.WriteLine("Visa en specifik kontakt... \n");
        Console.Write("Ange för och efternamn: ");
        var contactName = Console.ReadLine();
        contactName = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(contactName!.ToLower());
        var contact = contacts.Find(x => x.FirstName + " " + x.LastName == contactName);
        Console.Clear();
        Console.WriteLine("Förnamn: " + contact!.FirstName);
        Console.WriteLine("Efternamn: " + contact!.LastName);
        Console.WriteLine("E-postadress: " + contact!.Email);
        Console.WriteLine("Telefonnummer: " + contact!.PhoneNumber);
        Console.WriteLine("Adress: " + contact!.Adress + ", " + contact!.PostalCode + " " + contact!.City);
        Console.WriteLine("----------------------------------------------------------------------------------------------------------");
        Console.WriteLine("Tryck valfri tangent för att återgå till Adressboken...");
        Console.ReadKey();
    }
    private void RunOptionFour()
    {
        Console.Clear();
        Console.WriteLine("Ta bort en specifik Kontakt... \n");
        Console.Write("Ange för och efternamn på kontakten du vill ta bort: ");
        var contactName = Console.ReadLine();
        contactName = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(contactName!.ToLower());
        var contact = contacts.Find(x => x.FirstName + " " + x.LastName == contactName);
        bool y = true;

        do
        {
            Console.Clear();
            Console.WriteLine("Är du säker på att du vill ta bort " + contactName + " från listan?");
            Console.Write("J = Ja | N = Nej: ");
            string answer = Console.ReadLine()!.ToUpper();

            if (answer == "J")
            {
                y = false;
                contacts.RemoveAll(x => x.FirstName + " " + x.LastName == contactName);
                file.Save(FilePath, JsonConvert.SerializeObject(contacts));
                Console.WriteLine(contactName + " har blivit borttagen.");
            }
            else if (answer == "N")
            {
                Console.WriteLine(contactName + " har ej blivit borttagen");
                y = false;
            }

            else
            {
                Console.WriteLine("Kunde inte registrera ditt val, tryck valfri tangent för att försöka igen");
                Console.ReadKey();
            }
        } while (y == true);

        Console.WriteLine("Tryck valfri tangent för att återgå till Adressboken...");
        Console.ReadKey();
    }
}
