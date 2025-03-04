using Contacts.Maui.Models;
using Contacts.UseCases.Interfaces;
using Contact = Contacts.CoreBusiness.Contact;
using Microsoft.Maui.ApplicationModel.Communication;

namespace Contacts.Maui.Views;

public partial class AddContactPage : ContentPage
{
    private readonly IAddContactUseCase addContactUseCase;

    public AddContactPage(IAddContactUseCase addContactUseCase)
	{
		InitializeComponent();
        this.addContactUseCase = addContactUseCase;
    }

    private async void contactCtrl_OnSave(object sender, EventArgs e)
    {
        await addContactUseCase.ExecuteAsync(new Contact
        {
            Name = contactCtrl.Name,
            Email = contactCtrl.Email,
            Phone = contactCtrl.Phone,
            Address = contactCtrl.Address
        });

        await Shell.Current.GoToAsync("..");
    }

    private void contactCtrl_OnCancel(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    private void contactCtrl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e.ToString(), "OK");
    }
}