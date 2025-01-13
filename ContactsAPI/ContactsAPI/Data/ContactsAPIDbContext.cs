using ContactsAPI.Models;
using Microsoft.EntityFrameworkCore;

//

namespace ContactsAPI.Data
{
    public class ContactsAPIDbContext : DbContext
    {
        public ContactsAPIDbContext(DbContextOptions options) : base(options)  //default Konstruktor mit DI der options
        {

        }

        //Property(Eigenschaft) und kein Konstruktor, der die Struktur von
        //der Klasse Contact als DatenbankSet verwaltet
        public DbSet<Contact> Contacts  { get; set; }   //Hier wird EF Core angewiesen, eine Tabelle namens Contacts zu erstellen,
                                                        //basierend auf der Klasse Contacts.


        //Hier wird die Property mittels di bereitgestellt.
        public DbSet<FullNameContactRequest> FullNameContactRequests { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FullNameContactRequest>().HasNoKey(); //Achtung, Kein Primärschlüssel bei dem Model
            base.OnModelCreating(modelBuilder);
        }

    }
}
