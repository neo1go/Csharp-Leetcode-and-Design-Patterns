namespace ContactsAPI.Models
{

    // Dies ist eigentlich kein ganzes Model sondern ein DTO, weil hier nicht
    // die ganze DB abgebildet wird sondern nur bestimmte Teile davon übertragen werden.
    // Die Id fehlt und wird von der DB hinzugefügt.

    // weil es sich um ein dto handelt und es normalerweise keine eigene Logik besitzt,
    // gehört dies eigentlich zum PL oder SL (Presentation Layer, ServiceLayer)


    public class AddContactRequest                         //Hinzufügen eines neuen Kontakts
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Telefon { get; set; }
        public string? Address { get; set; }
    }
}
