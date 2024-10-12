using ContactsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsAPI.Data
{
    public class ContactsAPIDbContext : DbContext
    {
        public ContactsAPIDbContext(DbContextOptions options) : base(options)  //default Konstruktor mit DI der options
        {
        }

        public DbSet<Contact> Contacts  { get; set; }   //Property(Eigenschaft) und kein Konstruktor, der die Struktur von
                                                        //der Klasse Contact als DatenbankSet verwaltet
    }
}
