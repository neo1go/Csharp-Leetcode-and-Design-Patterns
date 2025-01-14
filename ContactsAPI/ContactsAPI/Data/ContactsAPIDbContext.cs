using ContactsAPI.Models;
using Microsoft.EntityFrameworkCore;

// Dies ist das Data Access Layer
// Dies ist der zentrael Punkt zwischen Anwendung und der Datenbank
// Hier wird die Verbindung zwischen der DB und den Model-Klassen bzw. den DTO's vorgenommen.
// Mittels dependency injection setzt man hier die Verbindung der beiden Bereiche.

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


        // Dies ist eine framework-Methode mit der man in diesem Fall das dto FullNameContactRequest
        // so definieren kann, das es Daten empfangen kann, die keinen PK besitzen.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FullNameContactRequest>().HasNoKey(); //Achtung, Kein Primärschlüssel bei dem Model/dto
            base.OnModelCreating(modelBuilder);
        }

    }
}
