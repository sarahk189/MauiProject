using AddressBookShared.Interfaces;
using AddressBookShared.Models;
using AddressBookShared.Services;
using Moq;

namespace AddressBookShared.Tests;

public class ContactService_Tests
{
    [Fact]
    public void AddContactToList_ShouldAddContactWhenEmailIsValid()
    {
        // Arrange
        IContact contact = new Contact
        {
            FirstName = "Sarah",
            LastName = "Kriborg",
            PhoneNumber = 12345678,
            Email = "sarah@gmail.com",
            StreetName = "Bankgatan",
            StreetNumber = 123,
            City = "Helsingborg",
            PostalCode = 123456,
            Country = "Sweden"
        };

        var mockFileManager = new Mock<IFileManager>();

        ContactService contactService = new ContactService(mockFileManager.Object);

        // Act
        contactService.AddContactToList(contact);

        // Assert 
        Assert.Contains(contact, contactService.Contacts);
    }

    [Fact]
    public void GetContactsFromList_ShouldGetAllContactsFromList_ReturnListOfContacts()
    {
        //Arrange
        IContact contact = new Contact
        {
            FirstName = "Sarah",
            LastName = "Kriborg",
            PhoneNumber = 12345678,
            Email = "sarah@gmail.com",
            StreetName = "Bankgatan",
            StreetNumber = 123,
            City = "Helsingborg",
            PostalCode = 123456,
            Country = "Sweden"
        };

        var mockFileManager = new Mock<IFileManager>();
        
        IContactService contactService = new ContactService(mockFileManager.Object);

        contactService.AddContactToList(contact);

        //Act
        IEnumerable<IContact> result = contactService.GetContactsFromList();

        //Assert
        Assert.NotNull(result);
        Assert.True(result.Any());
        IContact returnedContact = result.FirstOrDefault()!;
        Assert.Equal("Sarah", returnedContact.FirstName);
    }

    [Fact]
    public void UpdateContactList_ShouldUpdateContactDetails_WhenContactExists()
    {
        // Arrange
        var mockFileManager = new Mock<IFileManager>();
        var contactService = new ContactService(mockFileManager.Object);

        var originalContact = new Contact { Email = "test@example.com", FirstName = "Original" };
        contactService.AddContactToList(originalContact);

        var updatedContact = new Contact { Email = "test@example.com", FirstName = "Updated" };

        // Act
        contactService.UpdateContactList(updatedContact);

        // Assert
        var contactInList = contactService.Contacts.First(c => c.Email == "test@example.com");
        Assert.Equal("Updated", contactInList.FirstName);
    }

    [Fact]
    public void RemoveContactFromList_ShouldRemoveContact_WhenContactExists()
    {
        // Arrange
        var mockFileManager = new Mock<IFileManager>();
        var contactService = new ContactService(mockFileManager.Object);

        var contact = new Contact { Email = "test@example.com" };
        contactService.AddContactToList(contact);

        // Act
        contactService.RemoveContactFromList(contact);

        // Assert
        Assert.DoesNotContain(contact, contactService.Contacts);
    }

    [Fact]
    public void SaveContactsToFile_ShouldCallFileManagerSaveMethod()
    {
        // Arrange
        var mockFileManager = new Mock<IFileManager>();
        mockFileManager.Setup(m => m.SaveContentToFile(It.IsAny<string>(), It.IsAny<string>()))
                       .Returns(true)
                       .Verifiable();

        var contactService = new ContactService(mockFileManager.Object);
        var contact = new Contact { Email = "test@example.com" };

        // Act
        contactService.SaveContactsToFile(); // This method should be public or internal for testing

        // Assert
        mockFileManager.Verify(m => m.SaveContentToFile(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
    }


}
