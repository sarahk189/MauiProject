using MauiProject.Pages;

namespace MauiProject
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(AddressBookFormPage), typeof(AddressBookFormPage));
            Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
            Routing.RegisterRoute(nameof(UpdatePage),typeof(UpdatePage));
        }
    }
}
