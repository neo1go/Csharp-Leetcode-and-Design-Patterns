using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Turnierplaner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // TODO - alle später wieder private setzen
        public string passiveSinglePLayerFilePath = @"C:\Users\Willkommen\source\repos\Turnierplaner\Turnierdaten\TurnierdatenpassiveEinzelspieler\passiveSinglePlayer.csv";
        public string activeSinglePLayersFilePath = @"C:\Users\Willkommen\source\repos\Turnierplaner\Turnierdaten\TurnierdatenaktiveEinzelspieler\activeSinglePlayers.csv";
        public string passiveTeamFilePath = @"C:\Users\Willkommen\source\repos\Turnierplaner\Turnierdaten\TurnierdatenpassiveTeams\passiveTeam.csv";
        public string activeTeamFilePath = @"C:\Users\Willkommen\source\repos\Turnierplaner\Turnierdaten\TurnierdatenaktiveTeams\activeTeam.csv";
        //Diese Collections werden erstellt um sofort die Listboxen mit Daten zu befüllen falls vorhanden
        //TODO - diese 4 nachher wieder private setzen
        public ObservableCollection<PersonModel> allPlayers = new ObservableCollection<PersonModel>();
        public ObservableCollection<PersonModel> activePlayers = new ObservableCollection<PersonModel>();
        public ObservableCollection<TeamModel> allTeams = new ObservableCollection<TeamModel>();
        public ObservableCollection<TeamModel> activeTeams = new ObservableCollection<TeamModel>();

        
        public MainWindow()
        {
            InitializeComponent();

            allPlayerList_Click.ItemTemplate = (DataTemplate)this.Resources["PersonDataTemplate"];
            activePlayerList_Click.ItemTemplate = (DataTemplate)this.Resources["PersonDataTemplate2"];



            allPlayerList_Click.ItemsSource = allPlayers;
            activePlayerList_Click.ItemsSource = activePlayers;
            allTeamList_Click.ItemsSource = allTeams;
            activeTeams_Click.ItemsSource = activeTeams;

            LoadInitialPLayers();
        }

        // TODO - Diese ListBox Objekte nachher wieder zerstören.
        public ListBox allPlayersListBox => allPlayerList_Click;
        public ListBox activePlayersListBox => activePlayerList_Click;

        [STAThread] //STA - Single Threaded Apartment COM - Component Object Model
        // TODO - später wieder private
        public void LoadInitialPLayers()
        {
            // Lade passive Spieler
            var allPlayersData = ReadCsvFile(passiveSinglePLayerFilePath);
            foreach (var playerData in allPlayersData)
            {
                var player = new PersonModel
                {
                    Id = Guid.Parse(playerData[0]),
                    Vorname = playerData[1],
                    Nachname = playerData[2],
                    Adresse = playerData[3],
                    Email = playerData[4],
                    TelNr = playerData[5],
                    WonMatches = int.Parse(playerData[6]),
                    LostMatches = int.Parse(playerData[7]),
                };
                allPlayers.Add(player);
            }

            // Lade aktive Spieler
            var activePlayersData = ReadCsvFile(activeSinglePLayersFilePath);
            foreach (var playerData in activePlayersData)
            {
                var player = new PersonModel
                {
                    Id = Guid.Parse(playerData[0]),
                    Vorname = playerData[1],
                    Nachname = playerData[2],
                    Adresse = playerData[3],
                    Email = playerData[4],
                    TelNr = playerData[5],
                    WonMatches = int.Parse(playerData[6]),
                    LostMatches = int.Parse(playerData[7]),
                };
                activePlayers.Add(player);
            }
        }


        // TODO - später wieder private
        public void CreateNewPlayer_Click(object sender, RoutedEventArgs e)
        {
            string filePath = passiveSinglePLayerFilePath;
            //New Player wird immer zuerst zur passive List hinzugefügt per Button Klick
            var person = new PersonModel
            {
                Id = Guid.NewGuid(),
                Vorname = firstName_Input.Text,
                Nachname = lastName_Input.Text,
                Adresse = adress_Input.Text,
                Email = eMail_Input.Text,
                TelNr = telNr_Input.Text,
                WonMatches = int.Parse(wonMatches_Input.Text),
                LostMatches = int.Parse(lostMatches_Input.Text),
            };
            //Format zum Speichern bei der es auch einen GUID gibt
            string csvLine = $"{person.Id},{person.Vorname},{person.Nachname},{person.Adresse},{person.Email},{person.TelNr},{person.WonMatches},{person.LostMatches}";

            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, true, Encoding.UTF8))
                {
                    sw.WriteLine(csvLine);
                }
                UpdateListBox(allPlayerList_Click, person);//Listbox mit neuem Spieler befüllt

                MessageBox.Show("Daten wurden erfolgreich gespeichert.");
            }
            catch (IOException ex)
            {

                MessageBox.Show($"Fehler bim Speichern der Datei: {ex.Message}");
            }

            // TODO - passive List in Main Window muß refresht werden nur mit Vornamen und Nachnamen des/der Spieler/in
        }


        // TODO - später wieder private
        //Hiermit wird ein Eintrag in die Textbox gemacht, egal ob es die aktive oder passive Box ist
        public void UpdateListBox(ListBox listBox, PersonModel player)
        {
            if (listBox != null && player != null)
            {
                // Setzt den Text der ListBox auf Vorname und Nachname in einer Zeile
                var collection = listBox.ItemsSource as ObservableCollection<PersonModel>; 
                collection?.Add(player);
            }
        }




        //TODO - später wieder auf private setzen
        public void SwitchPlayerList(PersonModel player, ListBox sourceListBox, ListBox targetListBox)
        {
            if (player == null || sourceListBox == null || targetListBox == null)
                return;

            string sourceFilePath = sourceListBox.Name == "allPlayerList_Click" ? passiveSinglePLayerFilePath : activeSinglePLayersFilePath;
            string targetFilePath = targetListBox.Name == "allPlayerList_Click" ? passiveSinglePLayerFilePath : activeSinglePLayersFilePath;

            // Entferne den Spieler aus der Quell-Liste
            RemovePlayerFromFile(sourceFilePath, player.Id.ToString());

            // Füge den Spieler zur Ziel-Liste hinzu
            AddPlayerToFile(targetFilePath, player);

            // Aktualisiere die ListBoxen
            var sourceCollection = sourceListBox.ItemsSource as ObservableCollection<PersonModel>;
            var targetCollection = targetListBox.ItemsSource as ObservableCollection<PersonModel>;

            sourceCollection?.Remove(player);
            targetCollection?.Add(player);

        }

        //TODO - später wieder private setzen
        public void AddPlayerToFile(string filePath, PersonModel player)
        {
            string csvLine = $"{player.Id},{player.Vorname},{player.Nachname},{player.Adresse},{player.Email},{player.TelNr},{player.WonMatches},{player.LostMatches}";

            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, true, Encoding.UTF8))
                {
                    sw.WriteLine(csvLine);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Fehler beim Speichern der Datei: {ex.Message}");
            }
        }

        //TODO - später wieder private setzen
        public void RemovePlayerFromFile(string filePath, string playerId)
        {
            List<string> allLines = File.ReadAllLines(filePath).ToList();
            //Hier werden alle Daten in die Variable geschrieben mit Ausnahme der zu löschenden Daten die anhand der playerId erkannt wurden.
            List<string> filteredLines = allLines.Where(line => !line.Split(',')[0].Equals(playerId, StringComparison.OrdinalIgnoreCase)).ToList();

            try
            {
                File.WriteAllLines(filePath, filteredLines, Encoding.UTF8);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Fehler beim Entfernen der Datei: {ex.Message}");
            }
        }


       

        //Event Handler
        private void AddPlayertoActiveList_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                PersonModel? player = button.DataContext as PersonModel;
                if (player != null)
                {
                    string filePath = activeSinglePLayersFilePath;
                    ListBox sourceListBox = allPlayerList_Click;
                    ListBox targetListBox = activePlayerList_Click;
                    SwitchPlayerList(player, sourceListBox, targetListBox);
                    AddPlayerToFile(filePath, player);
                }
                else
                {
                    MessageBox.Show("Der Spieler konnte nicht gefunden werden.");
                }
            }
            else
            {
                MessageBox.Show("Der Sender ist kein Button");
            }
        }




        //Event Handler
        private void RemovePlayerFromActiveList_Click(object sender, RoutedEventArgs e)
        {// TODO - die sender Sache klappt nicht so richtig 
            PersonModel player = (PersonModel)sender;

            string newFilePath = passiveSinglePLayerFilePath;
            string oldFilePath = activeSinglePLayersFilePath;
            ListBox sourceListBox = activePlayerList_Click;
            ListBox targetListBox = allPlayerList_Click;

            SwitchPlayerList(player, sourceListBox, targetListBox);           
            AddPlayerToFile(newFilePath, player);
            RemovePlayerFromFile(oldFilePath,player.Id.ToString());

        }


        private void MovePlayerFromListToList(ListBox listBox,PersonModel player)
        {
            if (listBox != null && player != null)
            {
                var collection = listBox.ItemsSource as ObservableCollection<PersonModel>;
                collection?.Remove(player);
            }
        }



        //Event Handler
        private void SavePlayer_Click(object sender, RoutedEventArgs e)
        {
            PersonModel person = new PersonModel();

            string filePath = string.Empty;
            string csvLine = $"{person.Id},{person.Vorname},{person.Nachname},{person.Adresse},{person.Email},{person.TelNr},{person.WonMatches},{person.LostMatches}";

            var focusedListbox = Keyboard.FocusedElement as ListBox; //aktive Listbox wird in Variable gesetzt

            if (focusedListbox != null)
            {
                if (focusedListbox.Name == "allPayerList_Click")
                {
                    filePath = passiveSinglePLayerFilePath;
                }
                else if (focusedListbox.Name == "activePlayerList_Click")
                {
                    filePath = activeSinglePLayersFilePath;
                }

            }

            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, true, Encoding.UTF8))
                {
                    sw.WriteLine(csvLine);
                }
                MessageBox.Show("Daten wurden erfolgreich gespeichert.");
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Fehler bim Speichern der Datei: {ex.Message}");
            }
        }



        //Event Handler
        private void AlterPlayer_Click(object sender, RoutedEventArgs e)
        {
            string filePath = string.Empty;
            PersonModel person = new PersonModel();
            string csvLine = $"{person.Id},{person.Vorname},{person.Nachname},{person.Adresse},{person.Email},{person.TelNr},{person.WonMatches},{person.LostMatches}";
            var focusedListbox = Keyboard.FocusedElement as ListBox; //aktive Listbox wird in Variable gesetzt

            if (focusedListbox != null)
            {
                if (focusedListbox.Name == "allPayerList_Click")
                {
                    filePath = passiveSinglePLayerFilePath;
                }
                else if (focusedListbox.Name == "activePlayerList_Click")
                {
                    filePath = activeSinglePLayersFilePath;
                }
            }
            // NEU Versuch///////////////////////////////////////////////////////////////////////
            EditEntry(person.Id,person.Vorname,person.Nachname,person.Adresse,person.Email,person.TelNr,person.WonMatches,person.LostMatches,filePath);
            
        }


        //Hier werden nur die Daten eingelesen anhand des Filepath
        private List<string[]> ReadCsvFile(string filePath)
        {
            var data = new List<string[]>();

            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath, Encoding.UTF8);
                foreach (var line in lines)
                {
                    var values = line.Split(',');
                    data.Add(values);
                }
            }
            return data;
        }


        

        private void EditEntry(Guid id, string neuerVorname, string neuerNachname, string neueAdresse, string neueTelNummer, string neueEMail, int neueWonMatches, int neueLostMatches, string filePath)
        {
            var data = ReadCsvFile(filePath);

            var entry = data.FirstOrDefault(row => row[0].Equals(id));
            if (entry != null)
            {
                entry[1] = neuerVorname;
                entry[2] = neuerNachname;
                entry[3] = neueAdresse;
                entry[4] = neueTelNummer;
                entry[5] = neueEMail;
                entry[6] = neueWonMatches.ToString();
                entry[7] = neueLostMatches.ToString();

                WriteCsvFile(data, filePath);

                MessageBox.Show("Eintrag wurde erfolgreich bearbeitet und gespeichert.");
            }
            else
            {
                MessageBox.Show("Eintrag mit der angegebenen ID nicht gefunden");
            }
        }


        private void WriteCsvFile(List<string[]> data, string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                foreach (var row in data)
                {
                    sw.WriteLine(string.Join(",", row));
                }
            }
        }


        private void ErasePlayer_Click(object sender, RoutedEventArgs e)
        {
            string filePath = string.Empty;
            var focusedListbox = Keyboard.FocusedElement as ListBox; //aktive Listbox wird in Variable gesetzt

            if (focusedListbox != null)
            {
                if (focusedListbox.Name == "allPayerList_Click")
                {
                    filePath = passiveSinglePLayerFilePath;
                }
                else if (focusedListbox.Name == "activePlayerList_Click")
                {
                    filePath = activeSinglePLayersFilePath;
                }
            }

            try
            {
                List<string> allLines = File.ReadAllLines(filePath).ToList();

                string lastNameToDelete = lastName_Input.Text; //ausgesuchter Nachname zum Löschen

                List<string> filteredLines = allLines
                    .Where(line => !line.Split(',')[2]     //durch den ! Operator wird diese komplette Zeile herausgenommen bzw es werden alle Zeilen gespeichert mit Ausnahme von dieser Zeile 
                    .Equals(lastNameToDelete, StringComparison
                    .OrdinalIgnoreCase))
                    .ToList();

                File.WriteAllLines(filePath, filteredLines, Encoding.UTF8);//Nach Änderung wieder an den alten Platz schreiben

                MessageBox.Show("Eintrag erfolgreich gelöscht.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Löschen des Eintrags: {ex.Message}");
            }
        }

        private void CreateTeam_Click(object sender, RoutedEventArgs e)
        {
            //TODO - Erstellt Teamnamen. Hier werden dann pro Namen die Spieler hinzugefügt
        }

        private void AddTeamToMatchList_Click(object sender, RoutedEventArgs e)
        {
            // TODO - hinzufügen zur aktiven Liste
        }

        private void RemoveTeamFromMatchList_Click(object sender, RoutedEventArgs e)
        {
            //TODO - Team nur aus der aktiven Liste für Turnier entfernen
        }

        private void EraseTeam_Click(object sender, RoutedEventArgs e)
        {
            //TODO - Löscht das Team (nicht die Einzelspieler)
        }

        private void AddPlayerToTeam_Click(object sender, RoutedEventArgs e)
        {
            //TODO - Spieler aus der Gesamtliste in die aktive Liste einfügen, mit der dann ein Turnier gestartet wird
        }

        private void RemovePlayerFromTeam_Click(object sender, RoutedEventArgs e)
        {
            // TODO - Nur aus aktiver TeamListe entfernen
        }

        private void CreateSinglePlayerMatch_Click(object sender, RoutedEventArgs e)
        {
            //TODO - Jeder gegen jeden oder klassisch 32-16-8-4-2-1
        }

        private void CreateTeamMatch_Click(object sender, RoutedEventArgs e)
        {
            // TODO - gesamten Spielbaum anzeigen lassen mit zumindest Teamnamen auf neuer Seite
        }

        private void PrizeMoney_Click(object sender, RoutedEventArgs e)
        {
            // TODO - neue Seite zum Berechnen und Darstellen des Preisgelds.
            //        speichern der Werte pro Team
            //Button muß auf die Turnierseite - dann sind alle aktiven Teilnehmer anwesend und es ist dann auch korrekt zu berechnen
        }

        //TODO - Turnierseite erstellen mit Berechnung des Preisgeldes


    }



}