
using MauiProject.ViewModels;
using System.Diagnostics;


namespace MauiProject.Pages;


[QueryProperty(nameof(ContactEmail), "email")]
public partial class DetailsPage : ContentPage
{
    public DetailsPage(DetailsPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private string _contactEmail = string.Empty;

    public string ContactEmail
    {
        set
        {
            _contactEmail = Uri.UnescapeDataString(value ?? string.Empty);
            LoadContact(_contactEmail);
        }
    }

    private void LoadContact(string email)
    {
        var viewModel = (DetailsPageViewModel)BindingContext;
        viewModel.GetContactFromList(email);
    }
}


