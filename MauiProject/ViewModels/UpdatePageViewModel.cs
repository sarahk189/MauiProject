using AddressBookShared.Interfaces;
using AddressBookShared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace MauiProject.ViewModels;

public partial class UpdatePageViewModel : ObservableObject, IQueryAttributable
{
    
    private readonly IContactService _contactService;
    

    public UpdatePageViewModel(IContactService contactService)
    {
        _contactService = contactService;
    }

    [ObservableProperty]
    private IContact contact = new AddressBookShared.Models.Contact();

    [RelayCommand]
    public async Task UpdateContactList()
    {
        if (Contact != null && IsValidContact(Contact))
        {
            _contactService.UpdateContactList(Contact);
            await Shell.Current.GoToAsync("//MainPage");
        }
    }

    private bool IsValidContact(IContact contact)
    {
        if (string.IsNullOrWhiteSpace(contact.Email))
        {
            return false;
        }
        return true;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("Contact", out var contact) && contact is IContact receivedContact)
        {
            Contact = receivedContact;
        }
    }
}
