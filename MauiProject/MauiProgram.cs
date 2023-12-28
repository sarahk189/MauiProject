using AddressBookShared.Interfaces;
using AddressBookShared.Services;
using MauiProject.Pages;
using MauiProject.ViewModels;
using Microsoft.Extensions.Logging;

namespace MauiProject
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<IContactService, ContactService>();
            builder.Services.AddSingleton<IContact, AddressBookShared.Models.Contact>();

            builder.Services.AddSingleton<IFileManager, FileManager>();

            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<MainPage>();

            builder.Services.AddSingleton<DetailsPage>();
            builder.Services.AddTransient<DetailsPageViewModel>();

            builder.Services.AddSingleton<AddressBookFormPage>();
            builder.Services.AddSingleton<AddressBookFormPageViewModel>();

            builder.Services.AddSingleton<UpdatePage>();
            builder.Services.AddSingleton<UpdatePageViewModel>();

            builder.Logging.AddDebug();
            return builder.Build();
        }
    }
}

