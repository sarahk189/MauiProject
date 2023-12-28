using AddressBookShared.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiProject.Pages;
using Microsoft.Maui.ApplicationModel.Communication;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MauiProject.ViewModels;

public partial class MainViewModel : ObservableObject, INotifyPropertyChanged
{

    private readonly IContactService _contactService;


    public MainViewModel(IContactService contactService)
    {
        _contactService = contactService;
        GetContactsFromList();
    }

    [ObservableProperty]
    private ObservableCollection<IContact> _contactList = [];

    [ObservableProperty]
    private IContact? selectedContact;
    
    [RelayCommand]
    public void GetContactFromList(string email)
    {
        var contact = _contactService.GetContactFromList(email);
        if (contact != null)
        {
            SelectedContact = contact;
        }
    }

    [RelayCommand]
    public void GetContactsFromList()
    {
        var contacts = _contactService.GetContactsFromList();
        ContactList = new ObservableCollection<IContact>(contacts);
    }

    [RelayCommand]
    public void RemoveContactFromList(IContact contact)
    {
        if (contact != null)
        {
            _contactService.RemoveContactFromList(contact);
            // Optionally, you can refresh the ContactList here if it doesn't automatically update
            GetContactsFromList();
        }
    }


    [RelayCommand]
    private async Task NavigateToForm(IContact contact)
    {
        await Shell.Current.GoToAsync("AddressBookFormPage");
    }

    

    [RelayCommand]
    private async Task NavigateToDetails(IContact contact)
    {

        if (contact != null)
        {

            await Shell.Current.GoToAsync($"{nameof(DetailsPage)}?email={contact.Email}");

        }
    }

}