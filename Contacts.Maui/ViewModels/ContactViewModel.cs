﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contacts.Maui.Models;
using Contacts.Maui.Views_MVVM;
using Contacts.UseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Contact = Contacts.CoreBusiness.Contact;
using Microsoft.Maui.ApplicationModel.Communication;

namespace Contacts.Maui.ViewModels
{
    public partial class ContactViewModel : ObservableObject
    {
        private Contact contact;
        private readonly IViewContactUseCase viewContactUseCase;
        private readonly IEditContactUseCase editContactUseCase;
        private readonly IAddContactUseCase addContactUseCase;

        public Contact Contact
        {
            get => contact;
            set
            {
                SetProperty(ref contact, value);
            }
        }

        public bool IsNameProvided { get; set; }
        public bool IsEmailProvided { get; set; }
        public bool IsEmailFormatValid { get; set; }

        public ContactViewModel(
            IViewContactUseCase viewContactUseCase,
            IEditContactUseCase editContactUseCase,
            IAddContactUseCase addContactUseCase)
        {
            this.Contact = new();
            this.viewContactUseCase = viewContactUseCase;
            this.editContactUseCase = editContactUseCase;
            this.addContactUseCase = addContactUseCase;
        }

        public async Task LoadContact(int contactId)
        {
            this.Contact = await this.viewContactUseCase.ExecuteAsync(contactId);
        }

        [RelayCommand]
        public async Task EditContact()
        {
            if (await ValidateContact())
            {
                await this.editContactUseCase.ExecuteAsync(this.contact.ContactId, this.contact);
                await Shell.Current.GoToAsync(nameof(ContactsPage_MVVM));
            }
        }

        [RelayCommand]
        public async Task AddContact()
        {
            if (await ValidateContact())
            {
                await this.addContactUseCase.ExecuteAsync(this.contact);
                await Shell.Current.GoToAsync(nameof(ContactsPage_MVVM));
            }
        }

        [RelayCommand]
        public async Task BackToContactsPage()
        {
            await Shell.Current.GoToAsync(nameof(ContactsPage_MVVM));
        }

        private async Task<bool> ValidateContact()
        {
            if (!this.IsNameProvided)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Name is required.", "OK");
                return false;

            }
            if (!this.IsEmailProvided)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Email is required.", "OK");
                return false;
            }
            if (!this.IsEmailFormatValid)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Email format is not valid.", "OK");
                return false;
            }
            return true;
        }
    }
}
