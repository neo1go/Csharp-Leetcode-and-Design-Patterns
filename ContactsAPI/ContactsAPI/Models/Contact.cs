namespace ContactsAPI.Models
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }        
        public string Address { get; set; }
    }
}
