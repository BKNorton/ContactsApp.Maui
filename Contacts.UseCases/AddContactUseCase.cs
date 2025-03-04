using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contacts.UseCases.Interfaces;
using Contacts.UseCases.PlugInInterfaces;
using Contact = Contacts.CoreBusiness.Contact;
using Microsoft.Maui.ApplicationModel.Communication;

namespace Contacts.UseCases
{
    public class AddContactUseCase : IAddContactUseCase
    {
        private readonly IContactRepository contactRepostory;

        public AddContactUseCase(IContactRepository contactRepostory)
        {
            this.contactRepostory = contactRepostory;
        }

        public async Task ExecuteAsync(Contact contact)
        {
            await this.contactRepostory.AddContactAsync(contact);
        }
    }
}
