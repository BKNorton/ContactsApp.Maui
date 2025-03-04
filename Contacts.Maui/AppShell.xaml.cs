﻿using Contacts.Maui.Views;
using Contacts.Maui.Views_MVVM;

namespace Contacts.Maui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            //Routing.RegisterRoute(nameof(ContactsPage), typeof(ContactsPage));
            Routing.RegisterRoute(nameof(EditContactPage), typeof(EditContactPage));
            Routing.RegisterRoute(nameof(AddContactPage), typeof(AddContactPage));
            Routing.RegisterRoute(nameof(ContactsPage_MVVM), typeof(ContactsPage_MVVM));
            Routing.RegisterRoute(nameof(EditContactPage_MVVM), typeof(EditContactPage_MVVM));
            Routing.RegisterRoute(nameof(AddContactPage_MVVM), typeof(AddContactPage_MVVM));
        }
    }
}