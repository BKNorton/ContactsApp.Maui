using Contacts.UseCases.PlugInInterfaces;
using Contact = Contacts.CoreBusiness.Contact;
using Microsoft.Maui.ApplicationModel.Communication;

namespace Contacts.Plugins.DataStore.InMemory
{
    // All the code in this file is included in all platforms.
    public class ContactInMemoryRepository : IContactRepository
    {
        public static List<Contact> _contacts;

        public ContactInMemoryRepository()
        {
            _contacts = new List<Contact>()
            {
            new Contact() { ContactId=1, Name="John Doe", Email="JohnDoe@gmail.com"},
            new Contact() { ContactId=2, Name="Jane Doe", Email="JaneDoe@gmail.com"},
            new Contact() { ContactId=3, Name="Tom Hanks", Email="TomHanks@gmail.com"},
            new Contact() { ContactId=4, Name="Kirk Norton", Email="KirkNorton@gmail.com"},
            };
        }

        public Task AddContactAsync(Contact contact)
        {
            var maxId = _contacts.Max(x => x.ContactId);
            contact.ContactId = maxId + 1;
            _contacts.Add(contact);
            return Task.CompletedTask;
        }

        public Task DeleteContactAsync(int contactId)
        {
            var contact = _contacts.FirstOrDefault(x => x.ContactId == contactId);

            if (contact != null)
            {
                _contacts.Remove(contact);
            }
            return Task.CompletedTask;
        }

        public Task<List<Contact>> GetContactsAsync(string filterText)
        {
            var contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Name) && x.Name.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();

            if (string.IsNullOrWhiteSpace(filterText))
            {
                return Task.FromResult(_contacts);
            }

            if (contacts == null || contacts.Count <= 0)
            {
                contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Email) && x.Email.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
            }
            else return Task.FromResult(contacts);

            if (contacts == null || contacts.Count <= 0)
            {
                contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Phone) && x.Phone.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
            }
            else return Task.FromResult(contacts);

            if (contacts == null || contacts.Count <= 0)
            {
                contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Address) && x.Address.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
            }
            else return Task.FromResult(contacts);

            return Task.FromResult(contacts);
        }

        public Task<Contact> GetContactByIdAsync(int contactId)
        {
            var contact = _contacts.FirstOrDefault(x => x.ContactId == contactId);
            if (contact != null)
            {
                return Task.FromResult(new Contact
                {
                    ContactId = contact.ContactId,
                    Name = contact.Name,
                    Email = contact.Email,
                    Phone = contact.Phone,
                    Address = contact.Address
                });
            }
            return null;
        }

        public Task UpdateContactAsync(int contactId, Contact contact)
        {
            if (contactId != contact.ContactId) return Task.CompletedTask;

            var contactToUpdate = _contacts.FirstOrDefault(x => x.ContactId == contactId);
            if (contactToUpdate != null)
            {
                contactToUpdate.Name = contact.Name;
                contactToUpdate.Email = contact.Email;
                contactToUpdate.Phone = contact.Phone;
                contactToUpdate.Address = contact.Address;
            }

            return Task.CompletedTask;
        }
    }
}