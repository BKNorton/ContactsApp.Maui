using Contact = Contacts.CoreBusiness.Contact;

namespace Contacts.UseCases.PlugInInterfaces
{
    public interface IContactRepository
    {
        Task AddContactAsync(Contact contact);
        Task DeleteContactAsync(int contactId);
        Task<List<Contact>> GetContactAsync(string filterText);
        Task<Contact> GetContactByIdAsync(int contactId);
        Task UpdateContactAsync(int contactId, Contact contact);
    }
}
