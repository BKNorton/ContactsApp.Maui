using Contacts.UseCases.Interfaces;
using Contacts.UseCases.PlugInInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contact = Contacts.CoreBusiness.Contact;

namespace Contacts.UseCases
{
    public class ViewContactUseCase : IViewContactUseCase
    {
        private readonly IContactRepository contactRepostory;

        public ViewContactUseCase(IContactRepository contactRepostory)
        {
            this.contactRepostory = contactRepostory;
        }

        public async Task<Contact> ExecuteAsync(int contactId)
        {
            return await contactRepostory.GetContactByIdAsync(contactId);
        }
    }
}
