using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EnglischWörterbuchChemnitz
{
    public partial class MainWindow : Window
    {
        private Dictionary<string, List<string>>? wörterbuch;

        public MainWindow()
        {
            InitializeComponent();
         //   LoadDictionary();
        }
        //   Die Variante, bei der das gesamte Wörterbuch in den Speicher geladen wird.
        //private void LoadDictionary()
        //{
        //    wörterbuch = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
        //    string filePath = @"C:\ÜbersetzungGH\textdaten\de-en.txt";

        //    if (!File.Exists(filePath))
        //    {
        //        MessageBox.Show("Datei nicht gefunden: " + filePath);
        //        return;
        //    }
        //    try
        //    {
        //        using (StreamReader reader = new StreamReader(filePath))
        //        {
        //            string? line;
        //            while ((line = reader.ReadLine()) != null)
        //            {
        //                string[] parts = line.Split(new[] { "::" }, StringSplitOptions.None);
        //                if (parts.Length != 2) continue;

        //                string germanPart = parts[0].Trim();
        //                string englishPart = parts[1].Trim();

        //                string[] germanEntries = Regex.Split(germanPart, @"\s*[\|;]\s*");
        //                string[] englishEntries = Regex.Split(englishPart, @"\s*[\|;]\s*");

        //                List<string> englishList = englishEntries
        //                    .Where(eng => !string.IsNullOrWhiteSpace(eng))
        //                    .Select(eng => eng.Trim())
        //                    .ToList();

        //                foreach (string entry in germanEntries)
        //                {
        //                    string processedEntry = entry.Trim();

        //                    // Entferne Anmerkungen in {} und ()
        //                    //  processedEntry = Regex.Replace(processedEntry, @"\{.*?\}", "");
        //                    //  processedEntry = Regex.Replace(processedEntry, @"\(.*?\)", "");

        //                    // Extrahiere den Grundbegriff
        //                    string[] words = processedEntry.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        //                    var articles = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        //                    {
        //                        "der", "die", "das", "des", "dem", "den", "ein", "eine", "einer", "einem", "einen"
        //                    };

        //                    string baseTerm = words.FirstOrDefault(word => !articles.Contains(word)) ?? "";

        //                    if (string.IsNullOrEmpty(baseTerm) && words.Length > 0)
        //                        baseTerm = words[0];

        //                    if (!string.IsNullOrEmpty(baseTerm))
        //                    {
        //                        baseTerm = baseTerm.Trim();
        //                        if (wörterbuch.ContainsKey(baseTerm))
        //                        {
        //                            foreach (var def in englishList.Where(def => !wörterbuch[baseTerm].Contains(def)))
        //                            {
        //                                wörterbuch[baseTerm].Add(def);
        //                            }
        //                        }
        //                        else
        //                        {
        //                            wörterbuch[baseTerm] = new List<string>(englishList);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Fehler: " + ex.Message);
        //    }
        //}

        //private void SearchButton_Click(object sender, RoutedEventArgs e)
        //{
        //    string suchbegriff = SearchTextBox.Text.Trim();
        //    ResultsPanel.Children.Clear();

        //    if (string.IsNullOrEmpty(suchbegriff))
        //    {
        //        MessageBox.Show("Bitte Suchbegriff eingeben.");
        //        return;
        //    }

        //    var treffer = wörterbuch
        //        .Where(kvp => kvp.Key.Equals(suchbegriff, StringComparison.OrdinalIgnoreCase))
        //        .SelectMany(kvp => kvp.Value)
        //        .ToList();

        //    if (treffer.Any())
        //    {
        //        ResultsPanel.Children.Add(new TextBlock
        //        {
        //            Text = $"Ergebnisse für '{suchbegriff}':",
        //            FontWeight = FontWeights.Bold
        //        });

        //        foreach (string definition in treffer)
        //        {
        //            ResultsPanel.Children.Add(new TextBlock
        //            {
        //                Text = $"- {definition}",
        //                Margin = new Thickness(0, 2, 0, 0)
        //            });
        //        }
        //    }
        //    else
        //    {
        //        ResultsPanel.Children.Add(new TextBlock
        //        {
        //            Text = $"Keine Treffer für '{suchbegriff}'."
        //        });
        //    }
        //}



        //Bei dieser Varianter wird immer auf die Festplatte zugegriffen bei jeder Abfrage und nur zeilenweise eingelesen.
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string suchbegriff = SearchTextBox.Text.Trim(); //Dies ist die eingegebene Variable
            ResultsPanel.Children.Clear();

            if (string.IsNullOrEmpty(suchbegriff))
            {
                MessageBox.Show("Bitte Suchbegriff eingeben.");
                return;
            }

            string filePath = @"C:\ÜbersetzungGH\textdaten\de-en.txt"; 
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Datei nicht gefunden: " + filePath);
                return;
            }

            var treffer = new HashSet<string>(StringComparer.OrdinalIgnoreCase); //Duplikate und Groß/Kleinschreibung werden ignoriert.

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(new[] { "::" }, StringSplitOptions.None);
                        if (parts.Length != 2) continue; //es gibt normalerweise immer genau 2 parts, deutsch und englisch.

                        string germanPart = parts[0].Trim();
                        string englishPart = parts[1].Trim();

                        // Prüfe, ob IRGENDEIN deutscher Eintrag in der Zeile dem Suchbegriff entspricht
                        bool hasMatch = false;
                        string[] germanEntries = Regex.Split(germanPart, @"\s*[\|;]\s*"); //erlaubte Trennzeichen
                        foreach (string entry in germanEntries)
                        {
                            string processedEntry = entry.Trim();//Leerzeichen abschneiden
                       //     processedEntry = Regex.Replace(processedEntry, @"\{.*?\}", ""); //Entfernen von Text in Klammern mittels 
                       //     processedEntry = Regex.Replace(processedEntry, @"\(.*?\)", "");

                            string[] words = processedEntry.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            var articles = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
                    {
                        "der", "die", "das", "des", "dem", "den", "ein", "eine", "einer", "einem", "einen"
                    };

                            string baseTerm = words.FirstOrDefault(word => !articles.Contains(word)) ?? "";
                            if (string.IsNullOrEmpty(baseTerm) && words.Length > 0)
                                baseTerm = words[0];

                            if (!string.IsNullOrEmpty(baseTerm) && baseTerm.Equals(suchbegriff, StringComparison.OrdinalIgnoreCase))
                            {
                                hasMatch = true;
                                break; // Ein Treffer reicht aus
                            }
                        }

                        if (hasMatch)
                        {
                            string[] englishEntries = Regex.Split(englishPart, @"\s*[\|;]\s*");//Teiler sind \ | ;
                            foreach (string eng in englishEntries)          // mit \s* werden führende oder nachfolgende Leerzeichen entfernt.
                            {
                                string trimmedEng = eng.Trim();
                                if (!string.IsNullOrEmpty(trimmedEng))
                                {
                                    treffer.Add(trimmedEng); // HashSet ignoriert Duplikate automatisch
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Lesen der Datei: " + ex.Message);
            }

            // Anzeige der Ergebnisse
            if (treffer.Any())            //wenn HashSet irgendwelche Daten enthält.
            {
                ResultsPanel.Children.Add(new TextBlock    //ResultsPanel ist ein Stackpanel-Name im XAML-Code
                {
                    Text = $"Ergebnisse für '{suchbegriff}':",  //Nur Einfügen des Suchbegriffs bei Treffer
                    FontWeight = FontWeights.Bold
                });

                foreach (string definition in treffer)
                {
                    ResultsPanel.Children.Add(new TextBlock    //Hier wird der ganze gefundene Inhalt hinzugefügt.
                    {
                        Text = $"- {definition}",
                        Margin = new Thickness(0, 2, 0, 0)
                    });
                }
            }
            else
            {
                ResultsPanel.Children.Add(new TextBlock
                {
                    Text = $"Keine Treffer für '{suchbegriff}'."
                });
            }
        }


        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Text = "";
            ResultsPanel.Children.Clear();
            SearchTextBox.Focus();
        }

        private void EndButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F11)
            {
                if (WindowState == WindowState.Maximized)
                {
                    WindowState = WindowState.Normal;
                    WindowStyle = WindowStyle.SingleBorderWindow; // Rahmen anzeigen
                }
                else
                {
                    WindowState = WindowState.Maximized;
                    WindowStyle = WindowStyle.None; // Rahmen ausblenden
                }
            }
            else if (e.Key == Key.Escape && WindowStyle == WindowStyle.None)
            {
                WindowState = WindowState.Normal;
                WindowStyle = WindowStyle.SingleBorderWindow;
            }
        }
    }
}