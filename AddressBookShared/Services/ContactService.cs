using AddressBookShared.Interfaces;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AddressBookShared.Services;

public class ContactService : IContactService
{

    private readonly IFileManager _fileManager;
    public List<IContact> Contacts { get; private set; } = [];

    public ContactService(IFileManager fileManager)
    {
        _fileManager = fileManager;
    }

    public event EventHandler? ContactUpdated;

    private string _filePath = @"c:\projects\contacts.json";

    public void AddContactToList(IContact contact)
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(contact.Email))
            {
                Contacts.Add(contact);

                string json = JsonConvert.SerializeObject(Contacts, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                bool result = _fileManager.SaveContentToFile(_filePath, json);
                Debug.WriteLine(result);
                ContactUpdated?.Invoke(this, EventArgs.Empty);
            }
        }
        catch (JsonException jsonEx)
        {
            Debug.WriteLine("ContactServices - AddContactToList: JSON serialization error: " + jsonEx.Message);
        }
    }


    public IEnumerable<IContact> GetContactsFromList()
    {
        try
        {
            var content = _fileManager.GetContentFromFile(_filePath);
            if (!string.IsNullOrEmpty(content))
            {
                Contacts = JsonConvert.DeserializeObject<List<IContact>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All }) ?? new List<IContact>();

            }
            return Contacts;
        }
        catch (Exception ex)
        {
            Debug.WriteLine("ContactServices - GetContactsToList: " + ex.Message);
            return Enumerable.Empty<IContact>();
        }
    }


    public IContact GetContactFromList(string email)
    {
        try
        {
            GetContactsFromList();

            var contact = Contacts.FirstOrDefault(x => x.Email == email);
            return contact ?? throw new InvalidOperationException("Contact not found");
        }
        catch (Exception ex)
        {
            Debug.WriteLine("ContactServices - GetContactFromList: " + ex.Message);
            throw;
        }
    }

    public void UpdateContactList(IContact updatedContact)
    {
        var contact = Contacts.FirstOrDefault(c => c.Email == updatedContact.Email);
        if (contact != null)
        {
            contact.FirstName = updatedContact.FirstName;
            contact.LastName = updatedContact.LastName;
            contact.Email = updatedContact.Email;
            contact.PhoneNumber = updatedContact.PhoneNumber;
            contact.StreetName = updatedContact.StreetName;
            contact.StreetNumber = updatedContact.StreetNumber;
            contact.PostalCode = updatedContact.PostalCode;
            contact.City = updatedContact.City;
            contact.Country = updatedContact.Country;

            SaveContactsToFile();
            ContactUpdated?.Invoke(this, EventArgs.Empty);
        }
    }


    public void RemoveContactFromList(IContact contact)
    {
        try
        {
            lock (Contacts)
            {
                var existingContact = Contacts.FirstOrDefault(x => x.Email == contact.Email);
                if (existingContact != null)
                {
                    bool removed = Contacts.Remove(existingContact);
                    if (removed)
                    {
                        SaveContactsToFile();
                        ContactUpdated?.Invoke(this, EventArgs.Empty);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("ContactServices - RemoveContactFromList: " + ex.Message);
        }
    }

    public void SaveContactsToFile()
    {
        try
        {
            string json = JsonConvert.SerializeObject(Contacts, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            bool isSaved = _fileManager.SaveContentToFile(_filePath, json);

            if (!isSaved)
            {
                Debug.WriteLine("Error: Failed to save contacts to file.");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("ContactServices - SaveContactsToFile: " + ex.Message);
        }
    }
}
