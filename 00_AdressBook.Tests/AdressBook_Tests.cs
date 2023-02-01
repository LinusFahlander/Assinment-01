using _00_AdressBook.Models;
using _00_AdressBook.Services;

namespace _00_AdressBook.Tests
{
    [TestClass]
    public class AdressBook_Tests
    {
        [TestMethod]
        public void Should_Add_Contact_TO_List()
        {
            // arrange
            StartMenu startMenu = new StartMenu();
            Contact contact = new Contact();

            // act
            startMenu.contacts.Add(contact);

            // assert
            Assert.AreEqual(1, startMenu.contacts.Count);
        }
    }
}