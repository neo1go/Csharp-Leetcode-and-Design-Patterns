namespace ContactsAPI.Models
{
    public class AddContactRequest                         //Hinzufügen eines neuen Kontakts
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Address { get; set; }
    }
}
