using System.ComponentModel;
using System.Windows;

namespace WPFBalkendarstellungRND
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;        //setzt den dataContext auf das aktuelle Fenster

            GenerateBarHeights();

        }


        private List<int> _barHeights;
        public List<int> BarHeights        //Property mit der man _barHeights kapselt
        {
            get
            {
                return _barHeights;
            }
            set
            {
                _barHeights = value;
                OnPropertyChanged(nameof(BarHeights));
            }
        }

        private void GenerateBarHeights()
        {
            Random rnd = new Random();
            _barHeights = new List<int>();

            for (int i = 0; i < 11; i++)
            {
                BarHeights.Add(rnd.Next(10, 50) + rnd.Next(10, 50));

            }
            OnPropertyChanged(nameof(BarHeights));
        }




        //Der EventHandler ist ein Delegate, der die Methode definiert die bei Änderung aufgerufen wird
        public event PropertyChangedEventHandler ? PropertyChanged;
        //Ein Event ist eine spezielle Art von Delegat der es Klassen und Objekten ermöglicht, auf Ereignisse zu reagieren (lose Kopplung) 

        protected void OnPropertyChanged(string propertyName)
        {
            //Hier wird das Event,das vorher vom EventHandler deklariert wurde, ausgelöst.

            //Es müssen 2 Parameter bereitgestellt werden,
            //das auslösende Objekt(this) und ein Objekt mit den geänderten Property Werten
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            //PropertyChangedEventArgs enthält den geänderten Namen der Property, um die genaue Änderung zu spezifizieren.
            //PropertyChanged ist eine container,der alle Methoden beinhalten kann die auf das Event reagieren sollen
        }

        private void GenerateNewHeights_Click(object sender, RoutedEventArgs e)
        {
            GenerateBarHeights();
        }
    }
}