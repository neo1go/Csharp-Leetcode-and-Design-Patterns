using System.Collections.ObjectModel;

namespace ListViewBeispielXAML
{
    public class MainViewModel
    {
        public ObservableCollection<LoggerEntry>? LoggerEntries { get; set; }

        public MainViewModel()
        {
            LoggerEntries = new ObservableCollection<LoggerEntry>
            {
                new LoggerEntry{Startzeit=DateTime.Now.AddHours(-1),
                    Endzeit=DateTime.Now,Name="Max Mustemann",Abteilung="IT"},
                new LoggerEntry{Startzeit=DateTime.Now.AddHours(-2),
                    Endzeit=DateTime.Now.AddHours(-1),Name="Erika Erikson", Abteilung="HR"}
            };
        }
    }
}
