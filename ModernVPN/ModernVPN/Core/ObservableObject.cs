using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ModernVPN.Core
{

    //Implementiert Interface zur Benachrichtigung falls sich eine Eigenschaft ändert
    internal class ObservableObject : INotifyPropertyChanged
        
    {
        //Event Handler um Änderungen zu erkennen
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
