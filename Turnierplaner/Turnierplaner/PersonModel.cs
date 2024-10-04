namespace Turnierplaner
{
    //Erstellen eines Spielers
    public class PersonModel
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Vorname { get; set; }
        public string? Nachname { get; set; }
        public string FullName => $"{Vorname} {Nachname}";
        public string? Adresse { get; set; }
        public string? Email { get; set; }
        public string? TelNr { get; set; }
        public int WonMatches { get; set; } = 0;
        public int LostMatches { get; set; } = 0;
       
    }
}
