using Contacts.UseCases.PlugInInterfaces;
using System.Text;
using System.Text.Json;

namespace Contacts.Plugins.DataStore.WebApi
{
    // All the code in this file is included in all platforms.
    public class ContactWebApiRepository : IContactRepository
    {
        private HttpClient _httpClient;
        private JsonSerializerOptions _serializerOptions;

        public ContactWebApiRepository()
        {
            _httpClient = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }
        public async Task AddContactAsync(CoreBusiness.Contact contact)
        {
            string json = JsonSerializer.Serialize<CoreBusiness.Contact>(contact, _serializerOptions);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            Uri uri = new Uri($"{Constants.WebApiBaseUrl}/contacts");

            await _httpClient.PostAsync( uri, content );
        }

        public async Task DeleteContactAsync(int contactId)
        {
            Uri uri = new Uri($"{Constants.WebApiBaseUrl}/contacts/{contactId}");
            await _httpClient.DeleteAsync( uri );
        }

        public async Task<CoreBusiness.Contact> GetContactByIdAsync(int contactId)
        {
            Uri uri = new Uri($"{Constants.WebApiBaseUrl}/contacts/{contactId}");
            CoreBusiness.Contact? contact = null;
            var response = await _httpClient.GetAsync( uri );
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                contact = JsonSerializer.Deserialize<CoreBusiness.Contact>(content, _serializerOptions);
            }

            if (contact != null)
            {
                return contact;
            }
            return new CoreBusiness.Contact();
        }

        public async Task<List<CoreBusiness.Contact>> GetContactsAsync(string filterText)
        {
            List<CoreBusiness.Contact>? contacts = new List<CoreBusiness.Contact>();

            Uri uri;
            if (string.IsNullOrEmpty(filterText))
            {
                uri = new Uri($"{Constants.WebApiBaseUrl}/contacts");
            }
            else
            {
                uri = new Uri($"{Constants.WebApiBaseUrl}/contacts?filterString={filterText}");
            }

            var response = await _httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                contacts = JsonSerializer.Deserialize<List<CoreBusiness.Contact>>(content, _serializerOptions);
            }
            return contacts;
        }

        public async Task UpdateContactAsync(int contactId, CoreBusiness.Contact contact)
        {
            string json = JsonSerializer.Serialize<CoreBusiness.Contact>(contact, _serializerOptions);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            Uri uri = new Uri($"{Constants.WebApiBaseUrl}/contacts/{contactId}");

            await _httpClient.PutAsync(uri, content);
        }
    }
}
