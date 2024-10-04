using ContactsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsAPI.Data
{
    public class ContactsAPIDbContext : DbContext
    {
        public ContactsAPIDbContext(DbContextOptions options) : base(options)  //default Konstruktor
        {
        }

        public DbSet<Contact> Contacts  { get; set; }   //Property(Eigenschaft) und kein Konstruktor 
    }
}
