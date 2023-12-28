using AddressBookShared.Interfaces;
using AddressBookShared.Models;
using MauiProject.ViewModels;

namespace MauiProject.Pages;

public partial class MainPage : ContentPage
{

    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is MainViewModel viewModel)
        {
            viewModel.GetContactsFromList();
        }
    }
}