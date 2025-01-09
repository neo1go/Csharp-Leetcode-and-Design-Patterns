using DataBindingToButtons.ViewModel;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


/*
-View
   - Bindet an ViewModel und zeigt UI-Komponenten an.
   - Beispiel: XAML - Dateien
- ViewModel
   - Enthält Logik und Commands (z. B. `RelayCommand`).
   - Beispiel: `MainViewModel` mit `RelayCommand` zur Steuerung der Benutzeraktionen.
- Model
   - Beinhaltet Daten und Geschäftslogik.
   - Beispiel: `PersonModel`, `OrderModel` (keine Commands).
*/

namespace DataBindingToButtons
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    

    //Dies ist der Codebehind für den XAMl-Bereich
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

         //              Dies ist ein Beispiel für das databinding zwischen Main-Window und xaml.

         // this.DataContext = new MainViewModel(); //hiermit wird definiert,das sich die angezeigten Daten
                                              //auf die Werte aus dem MainViewModel beziehen (in diesem Fall die List bzw. Collection)


          //  Dies ist die zweite Variante anstatt hier dann im XAML Code um die Daten zu binden mit Window.DataContext
        /*
                     < Window.DataContext >
                < viewmodel:MainViewModel ></ viewmodel:MainViewModel >
            </ Window.DataContext >
                    */
        }
    }
}