using CommunityToolkit.Maui;
using Contacts.UseCases.PlugInInterfaces;
using Contacts.Plugins.DataStore.InMemory;
using Contacts.Plugins.DataStore.SQLite;
using Microsoft.Extensions.Logging;
using Contacts.UseCases.Interfaces;
using Contacts.UseCases;
using Contacts.Maui.Views;
using Contacts.Maui.ViewModels;
using Contacts.Maui.Views_MVVM;

namespace Contacts.Maui
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
                })
                .UseMauiCommunityToolkit(); 

#if DEBUG
		builder.Logging.AddDebug();
#endif
            //builder.Services.AddSingleton<IContactRepository, ContactInMemoryRepository>();
            builder.Services.AddSingleton<IContactRepository, ContactSQLiteRepository>();
            builder.Services.AddSingleton<IViewContactsUseCase, ViewContactsUseCase>();
            builder.Services.AddSingleton<IViewContactUseCase, ViewContactUseCase>();
            builder.Services.AddSingleton<IEditContactUseCase, EditContactUseCase>();
            builder.Services.AddSingleton<IAddContactUseCase, AddContactUseCase>();
            builder.Services.AddSingleton<IDeleteContactUseCase, DeleteContactUseCase>();

            builder.Services.AddTransient<ContactsViewModel> ();
            builder.Services.AddTransient<ContactViewModel> ();

            builder.Services.AddTransient<ContactsPage>();
            builder.Services.AddTransient<EditContactPage>();
            builder.Services.AddTransient<AddContactPage>();

            builder.Services.AddTransient<ContactsPage_MVVM>();
            builder.Services.AddTransient<EditContactPage_MVVM>();
            builder.Services.AddTransient<AddContactPage_MVVM>();

            return builder.Build();
        }
    }
}