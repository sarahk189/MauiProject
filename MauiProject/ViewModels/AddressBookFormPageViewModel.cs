using AddressBookShared.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.ApplicationModel.Communication;
using System.Collections.ObjectModel;


namespace MauiProject.ViewModels;

public partial class AddressBookFormPageViewModel : ObservableObject
{

    private readonly IContactService _contactService;

    public AddressBookFormPageViewModel(IContactService contactService, IContact contact)
    {
        _contactService = contactService;
    }

    [ObservableProperty]
    private IContact contact = new AddressBookShared.Models.Contact();


    [RelayCommand]
    private async Task AddContactToList()
    {
        if (_contactService != null)
        {
            _contactService.AddContactToList(Contact);
            await Shell.Current.GoToAsync("//MainPage");
        }
    }

    [RelayCommand]
    private async Task NavigateToMain(IContact contact)
    {
        
        await Shell.Current.GoToAsync("//MainPage");
    }

}
