using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;

//System.Configuration muß eingebunden werden

namespace WPFConfigUebung
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Die Configuration-Bearbeitung ist vom framework.
        //Der ConfigurationManager ist statisch und mit der Methode OpenExeConfiguration
        //wird nur mitgeteilt,das das Programm die ausführbare Configurations Datei laden soll.
        //Das Argument für OpenExeConfiguration kann variieren, um z.B. für verschiedene User bereitgestellt zu werden.
        Configuration AppConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        string[] Languages = new string[] { "English", "Chinese" };
        string[] Themes= new string[]{"Dark","Light"};

        //Konstruktor
        public MainWindow()
        {

            InitializeComponent();
            

            //Hier werden die Quellen für die beiden dropdown Menüs befüllt mit den String Array Werten.
            LanguageComboBox.ItemsSource = Languages;
            ThemesComboBox.ItemsSource = Themes;

            //Hier werden die Konstruktor Default Werte genutzt,falls nooch keine Datei mit diesem Namen existiert.
            if (AppConfig.Sections["UISettings"] is null)
            {

                //Sections sind Gruppierungen von Settings, die die Bearbeitung erleichtern.
                //Falls also noch keine Datei existiert,wird hier ein neues Objekt instanziiert und dann gespeichert.
                AppConfig.Sections.Add("UISettings",new UISettings());
            }

            //Dieser typecast ist notwendig,da sich sonst auf das Objekt ConfigurationSection bezogen wird. 
            var UISettingSection = (UISettings)AppConfig.GetSection("UISettings");//es wird speziell auf UISettings verwiesen

            this.DataContext = UISettingSection;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Daten werden nun als Config-File im normalen Text-Format gespeichert.
            try
            {
                // Änderungen in der Konfiguration speichern
                AppConfig.Save();
                MessageBox.Show("Settings saved");
            }
            catch (Exception ex)
            {
                // Fehlerbehandlung, falls etwas schiefgeht
                MessageBox.Show($"Error saving settings: {ex.Message}");
            }
        }
    }
}