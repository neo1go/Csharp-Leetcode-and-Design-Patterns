
using ModernVPN.Core;
using ModernVPN.MVVM.Model;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;

namespace ModernVPN.MVVM.ViewModel
{
    internal class ProtectionViewModel : ObservableObject
    {
        //Properties - Eigenschaften

        public GlobalViewModel Global { get; } = GlobalViewModel.Instance;//für die awesome Checkbox die gloabl läuft



        //Liste von Servermodels aus der Collection
        public ObservableCollection<ServerModel> Servers { get; set; }

        //Private Feldvariable
        private string _connectionStatus;

        //öffentliche Property - Eigenschaft um Zugriff auf das private Feld _connectionStatus zu gewähren
        public string ConnectionStatus
        {
            get { return _connectionStatus; }
            set
            {
                _connectionStatus = value;
                OnPropertyChanged();  //hiermit wird der View mitgeteilt, das sich der Wert von ConnectionStatus geändert hat
            }
        }


        //Mit Command werden Benutzereingaben an Methoden im ViewModel gebunden
        public RelayCommand ConnectCommand { get; set; }
        public ProtectionViewModel()
        {
            Servers = new ObservableCollection<ServerModel>();
            for (int i = 0; i < 10; i++)
            {
                Servers.Add(new ServerModel
                {
                    Country = "Germany"
                });
            }
            ConnectCommand = new RelayCommand(o =>
            {
                ConnectionStatus = "Connecting..";
                var process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.WorkingDirectory = Environment.CurrentDirectory;

                /*Achtung Passwort kann rotieren oder verfallen   https://www.vpnbook.com      */
                /* Phonebook stimmt nicht oder die Datei muß erst noch angelegt werden.*/

                process.StartInfo.ArgumentList.Add(@"/c rasdial DE20 vpnbook b6xntv9 /phonebook:C:\Users\Willkommen\AppData\Roaming\Microsoft\Network\Connections\Pbk\rasphone.pbk");
                
                

                process.Start();
                process.WaitForExit();

                switch (process.ExitCode)
                {
                    case 0:
                        Debug.WriteLine("Success!");
                        ConnectionStatus = "Connected!";
                        break;
                    case 623:
                        Debug.WriteLine("Phonebook nicht gefunden.");
                        ConnectionStatus = "No Phonebook";
                        break;
                    case 868:
                        Debug.WriteLine("Name des RAS-Servers konnte nicht aufgelöst werden."); //RAS - Remote Access Server, man kann in cmd 'ipconfig/flushdns' eingeben, um den cache zu leeren.  
                        ConnectionStatus = "Can't resolve RAS-Server";                          //und zusätzlich noch ipconfig/release und dananch sofort ipconfig/renew
                        break;                                                                 
                    case 691:
                        Debug.WriteLine("Wrong credentials!");
                        ConnectionStatus = "Wrong credentials!";
                        break;
                    default:
                        Debug.WriteLine($"Error: {process.ExitCode}");
                        ConnectionStatus = "Error";
                        break;
                }
                // " 🗖 "  " 🗙 " " − "
                // um nachzuschauen, ob das VPN läuft, während dem Betrieb cmd öffnen und im Projektordner  "rasdial" eingeben
                // man kann dann auch auf https://www.whatsmyip.org nachschauen, ob man dort mit einer anderen IP auftaucht.
                // mit rasdial /d kann die Verbindung wohl getrennt werden.
            });


        }


        private void ServerBuilder()
        {
            var address = "DE20.vpnbook.com";
            var FolderPath = $"{Directory.GetCurrentDirectory()}/VPN";
            var PbkPath = $"{FolderPath}/{address}.pbk";

            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }
            if (File.Exists(PbkPath))
            {
                MessageBox.Show("Connection already exists.");
                return;
            }

            var sb = new StringBuilder();
            sb.AppendLine("[MyServer]");
            sb.AppendLine("MEDIA=rastapi");
            sb.AppendLine("Port=VPN2-0");
            sb.AppendLine("Device=WAN Miniport (IKEv2)");
            sb.AppendLine("DEVICE=vpn");
            sb.Append($"PhoneNumber={address}");
            File.WriteAllText(PbkPath, sb.ToString());
        }
    }
}
