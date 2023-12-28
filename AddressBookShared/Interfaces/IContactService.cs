using System.Collections.ObjectModel;

namespace AddressBookShared.Interfaces;
public interface IContactService
{
    event EventHandler ContactUpdated;

    /// <summary>
    /// Add a contact to the address book 
    /// </summary>
    /// <param name="contact">a contact of type IContact</param>
    /// <returns>returns true if successful or false if not successful or contact already exists</returns>
    public void AddContactToList(IContact contact);

    /// <summary>
    /// Display all contacts from the address book  
    /// </summary>
    /// <returns>returns Contacts if successful or empty Enumerable if not successful</returns>
    IEnumerable<IContact> GetContactsFromList();

    /// <summary>
    /// Removes a contact from the address book  
    /// </summary>
    /// <returns>returns Contact list if successful or debug comment if not successful</returns>
    public void RemoveContactFromList(IContact contact);

    /// <summary>
    /// Display a contact from the address book  
    /// </summary>
    /// <param name="email">Email of the contact</param>
    /// <returns>returns the contact if found, or null if not found</returns>
    public IContact GetContactFromList(string email);

    /// <summary>
    /// Update the contact list from the underlying data source.
    /// </summary>
    public void UpdateContactList(IContact contact);
}