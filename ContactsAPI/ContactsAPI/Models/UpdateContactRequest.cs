namespace ContactsAPI.Models
{
    public class UpdateContactRequest  //Diese Klasse dient dem Updaten des existierenden Eintrags
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Address { get; set; }

    }
}
