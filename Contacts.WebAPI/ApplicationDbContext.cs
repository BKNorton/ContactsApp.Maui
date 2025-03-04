using Microsoft.EntityFrameworkCore;
using Contacts.WebAPI.Models;

namespace Contacts.WebAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
