
using ContactBookWpf.Mvvm.Models;
using ContactBookWpf.Mvvm.Services;

namespace ContactBookWpf.Tests;

public class ContactServices_Tests
{
    [Fact]
    public void AddContactToListShould_AddOneContactToContactList_ThenReturnTrue()
    {
        //Arrange
        Contacts contacts = new Contacts { FirstName = "Henrik", LastName = "Starander", Email = "henrik@gmail.com", PhoneNumber = "07333333" };
        ContactServices contactsServices = new ContactServices();

        //Act
        bool result = contactsServices.AddContact(contacts);

        //Assert
        Assert.True(result);

    }

    [Fact]
    public void GetAllFromListShould_GetAllContactsInContactList_ThenReturnListOfContacts()
    {
        //Arrange0
        Contacts contacts = new Contacts { FirstName = "Henrik", LastName = "Starander", Email = "henrik@gmail.com", PhoneNumber = "07333333" };
        ContactServices contactsServices = new ContactServices();
        contactsServices.AddContact(contacts);

        //Act

        IEnumerable<Contacts> result = contactsServices.GetAll();

        //Assert
        Assert.NotNull(result);
        Assert.True(result.Any());

    }

   
}
