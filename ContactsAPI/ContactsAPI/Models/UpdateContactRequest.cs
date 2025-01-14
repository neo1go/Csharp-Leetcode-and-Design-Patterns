namespace ContactsAPI.Models
{
    //Diese Klasse dient dem Updaten des existierenden Eintrags.
    //Da sie genauso wie z.B. AddContactRequest angelegt ist, könnte man auch diese verwenden
    //um dann POST,PUT,DELETE oder GET durchzuführen.

    //Dies ist ein dto un kein Model.
    public class UpdateContactRequest  
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Telefon { get; set; }
        public string? Address { get; set; }

    }
}
