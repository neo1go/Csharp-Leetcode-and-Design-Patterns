
using ModernVPN.Core;
using System.Windows;

namespace ModernVPN.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject  //Observable Object hat das Interface zur Beobachtung von Änderungen in der View
    {

        /* Commands */
        /* Befehle, die bei Buttonklick ausgeführt werden. (Diese werden weiter unten im Constructor definiert)*/
        public RelayCommand MoveWindowCommand { get; set; }
        public RelayCommand ShutDownWindowCommand { get; set; }
        public RelayCommand MaximizeWindowCommand { get; set; }
        public RelayCommand MinimizeWindowCommand { get; set; }
        public RelayCommand ShowProtectionView {  get; set; }
        public RelayCommand ShowSettingsView {  get; set; }






        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }


        public ProtectionViewModel ProtectionVM { get; set; }

        public SettingsViewModel SettingsVM { get; set; }

        public MainViewModel()
        {
            ProtectionVM = new ProtectionViewModel(); //neue Instanz
            SettingsVM = new SettingsViewModel();
            CurrentView = ProtectionVM;

            


            Application.Current.MainWindow.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight; //Maximalgröße

            MoveWindowCommand = new RelayCommand(o => { Application.Current.MainWindow.DragMove(); });  //Zur Bewegung des gesamten Fensters
            ShutDownWindowCommand = new RelayCommand(o => { Application.Current.Shutdown(); });
            MaximizeWindowCommand = new RelayCommand(o =>
            {
                if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
                {
                    Application.Current.MainWindow.WindowState = WindowState.Normal;
                }
                else
                {
                    Application.Current.MainWindow.WindowState = WindowState.Maximized;
                }
            });
            MinimizeWindowCommand = new RelayCommand(o => { Application.Current.MainWindow.WindowState = WindowState.Minimized; });

            ShowProtectionView = new RelayCommand(o => { CurrentView = ProtectionVM; });

            ShowSettingsView = new RelayCommand(o => { CurrentView = SettingsVM; });
        }
    }
}
