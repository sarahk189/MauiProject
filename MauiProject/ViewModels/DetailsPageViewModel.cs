using AddressBookShared.Interfaces;
using AddressBookShared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.ApplicationModel.Communication;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MauiProject.ViewModels;

public partial class DetailsPageViewModel : ObservableObject
{
    private readonly IContactService _contactService;

    public DetailsPageViewModel(IContactService contactService)
    {
        _contactService = contactService;
        _contactService.ContactUpdated += (sender, e) =>
        {
            Contacts = new ObservableCollection<IContact>(_contactService.GetContactsFromList());
        };
        selectedContact = new AddressBookShared.Models.Contact();
    }

    [ObservableProperty]
    private ObservableCollection<IContact> _contacts = [];

    [ObservableProperty]
    private IContact selectedContact;

    public void GetContactFromList(string email)
    {
        var contact = _contactService.GetContactFromList(email);
        if (contact != null)
        {
            SelectedContact = contact;
        }
        
    }

    [RelayCommand]
    public async Task RemoveContactFromList(IContact contact)
    {
        if (contact != null)
        {
            _contactService.RemoveContactFromList(contact);
            Contacts = new ObservableCollection<IContact>(_contactService.GetContactsFromList());
            await Shell.Current.GoToAsync("///MainPage");
        }
        
    }

    [RelayCommand]
    private async Task NavigateToMain(IContact contact)
    {
        await Shell.Current.GoToAsync("///MainPage");
    }

    [RelayCommand]
    private async Task NavigateToUpdate(IContact contact)
    {
        try
        {
            if (contact != null)
            {
                var parameters = new Dictionary<string, object>
            {
                { "Contact", contact }
            };

                await Shell.Current.GoToAsync("//UpdatePage", parameters);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Navigation error: {ex.Message}");
        }
    }
}
