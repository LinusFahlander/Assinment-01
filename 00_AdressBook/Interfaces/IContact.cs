namespace _00_AdressBook.Interfaces;

internal interface IContact
{
    string FirstName { get; set; }
    string LastName { get; set; }
    string Email { get; set; }
    string PhoneNumber { get; set; }
    string Adress { get; set; }
    string PostalCode { get; set; }
    string City { get; set; }
}
