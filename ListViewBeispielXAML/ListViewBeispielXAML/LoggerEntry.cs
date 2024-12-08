namespace ListViewBeispielXAML
{
    public class LoggerEntry
    {
        public DateTime Startzeit { get; set; }
        public DateTime Endzeit { get; set; }
        public string? Name { get; set; }
        public string? Abteilung { get; set; }


        //Anstatt im XAML kann man die verkürzte DateTime auch so erzeugen und diese dann im Binding einsetzen
       // public string StartzeitFormatted => Startzeit.ToString("HH:mm:ss"); 
       // public string EndzeitFormatted => Endzeit.ToString("HH:mm:ss"); 
    }
}