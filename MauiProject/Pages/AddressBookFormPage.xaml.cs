using MauiProject.Pages;
using MauiProject.ViewModels;

namespace MauiProject.Pages;

public partial class AddressBookFormPage : ContentPage
{
    public AddressBookFormPage(AddressBookFormPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

}