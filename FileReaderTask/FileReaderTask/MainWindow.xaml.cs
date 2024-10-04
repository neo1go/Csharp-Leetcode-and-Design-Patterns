using System.IO;
using System.Windows;

namespace FileReaderTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async Task<string> LoadFileAsync()
        {
            string filePath = "C:\\Users\\Public\\Documents\\TestTextfuerWPF.txt";

            await Task.Delay(2000);

            string fileData = await File.ReadAllTextAsync(filePath);  //Text wird in Variable eingelesen

            return fileData;

        }

        private async void LoadFileButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string loadedContent = await LoadFileAsync();
                TextDisplay.Text = loadedContent;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Laden der Datei: {ex.Message}");
            }
        }
    }
}