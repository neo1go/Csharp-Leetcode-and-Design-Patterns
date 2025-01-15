
// Dies ist das DAL (data access Layer) oder die Domain-Schicht, je nach Zweck
// Es gibt eine klare Trennung zwischen Domain Models, Entity Models und DTO's.
// In diesem Fall handelt es sich um ein Entity-Model weil hier die Tabellenstruktur der DB 
// definiert wird.

namespace ContactsAPI.Models
{

    //Dies hier gilt als Model weil es alle DB-Tabellen abbildet.
    //Es repräsentiert die gesamten Tabellen in der Datenbank, also die komplette Datenstruktur für die Entitäten. 

    //Dies ist die Klassenstruktur der anzulegenden Daten. Diese werden durchs ORM (object relational mapping)
    //dann in eine Database umgewandelt.


    public class Contact
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Telefon { get; set; }        
        public string? Address { get; set; }
    }
}
